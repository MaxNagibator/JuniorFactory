using Domiki.Web.Business.Models;

namespace Domiki.Web.Models
{
    public static class DomikTypeDtoExtensions
    {
        public static DomikTypeDto ToDto(this DomikType t)
        {
            return new DomikTypeDto
            {
                Id = t.Id,
                Name = t.Name,
                LogicName = t.LogicName,
                MaxCount = t.MaxCount,
                MaxLevel = t.MaxLevel,
                Levels = t.Levels.Select(x => x.ToDto()).ToArray(),
            };
        }
    }
}