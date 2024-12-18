using Domiki.Web.Business.Models;

namespace Domiki.Web.Models
{
    public static class UpgradeLevelDtoExtensions
    {
        public static UpgradeLevelDto ToDto(this UpgradeLevel t)
        {
            return new UpgradeLevelDto
            {
                Value = t.Value,
                Resources = t.Resources.Select(x => x.ToDto()).ToArray(),
                Modificators = t.Modificators.Select(x => x.ToDto()).ToArray(),
                ReceiptIds = t.Receipts.Select(x => x.Id).ToArray(),
            };
        }
    }
}