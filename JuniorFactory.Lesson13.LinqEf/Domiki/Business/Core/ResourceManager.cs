using Domiki.Web.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Domiki.Web.Business.Core
{
    public class ResourceManager
    {
        private Data.ApplicationDbContext _context;

        // todo избавится от статиков
        private static ModificatorType[] _modificatorTypes;
        private static ResourceType[] _resourceTypes;
        private static Receipt[] _receipts;
        private static DomikType[] _domikTypes;

        public ResourceManager(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ModificatorType[] GetModificatorTypes()
        {
            if (_modificatorTypes == null)
            {
                _modificatorTypes = _context.ModificatorTypes.Select(x => new ModificatorType
                {
                    Id = x.Id,
                    LogicName = x.LogicName,
                    Name = x.Name,
                }).ToArray();
            }

            return _modificatorTypes;
        }

        public ResourceType[] GetResourceTypes()
        {
            if (_resourceTypes == null)
            {
                _resourceTypes = _context.ResourceTypes
                    .Select(x => new ResourceType { Id = x.Id, LogicName = x.LogicName, Name = x.Name }).ToArray();
            }

            return _resourceTypes;
        }

        public Receipt[] GetReceipts()
        {
            if (_receipts == null)
            {
                _receipts = _context.Receipts.Include(x => x.Resources).Select(x => new Receipt
                {
                    Id = x.Id,
                    LogicName = x.LogicName,
                    Name = x.Name,
                    PlodderCount = x.PlodderCount,
                    DurationSeconds = x.DurationSeconds,
                    InputResources = x.Resources.Where(x => x.IsInput)
                        .Select(x => new Resource
                        {
                            Type = new ResourceType { Id = x.ResourceTypeId },
                            Value = x.Value
                        }).ToArray(),
                    OutputResources = x.Resources.Where(x => !x.IsInput)
                        .Select(x => new Resource
                        {
                            Type = new ResourceType { Id = x.ResourceTypeId },
                            Value = x.Value
                        }).ToArray(),
                }).ToArray();
            }
            return _receipts;
        }

        public DomikType[] GetDomikTypes()
        {
            if (_domikTypes == null)
            {
                var modificators = _context.DomikTypeLevelModificators.ToArray();
                var recepts = _context.DomikTypeLevelRecepts.ToArray();
                var resources = _context.DomikTypeLevelResources.ToArray();
                _domikTypes = _context.DomikTypes.Include(x => x.Levels).ToArray().Select(domikType => new DomikType
                {
                    Id = domikType.Id,
                    LogicName = domikType.LogicName,
                    Name = domikType.Name,
                    MaxCount = domikType.MaxCount,
                    Levels = domikType.Levels.Select(level => new UpgradeLevel
                    {
                        Value = level.Value,
                        UpgradeSeconds = level.UpgradeSeconds,
                        MaxManufactureCount = level.MaxManufactureCount,
                        Modificators = modificators
                            .Where(m => m.DomikTypeLevelDomikTypeId == domikType.Id
                                && m.DomikTypeLevelValue == level.Value)
                            .Select(x => new Modificator { Type = new ModificatorType { Id = x.ModificatorTypeId }, Value = x.Value }).ToArray(),
                        Receipts = recepts
                            .Where(m => m.DomikTypeLevelDomikTypeId == domikType.Id
                                && m.DomikTypeLevelValue == level.Value)
                            .Select(x => new Receipt { Id = x.ReceiptId }).ToArray(),
                        Resources = resources
                            .Where(m => m.DomikTypeLevelDomikTypeId == domikType.Id
                                && m.DomikTypeLevelValue == level.Value)
                            .Select(x => new Resource { Type = new ResourceType { Id = x.ResourceTypeId }, Value = x.Value }).ToArray(),
                    }).ToArray(),
                }).ToArray();
            }
            return _domikTypes;
        }
    }
}
