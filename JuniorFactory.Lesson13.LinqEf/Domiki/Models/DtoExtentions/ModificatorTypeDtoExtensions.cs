using Domiki.Web.Business.Models;

namespace Domiki.Web.Models
{
    public static class ModificatorTypeDtoExtentions
    {
        public static ModificatorTypeDto ToDto(this ModificatorType resourceType)
        {
            return new ModificatorTypeDto { Id = resourceType.Id, LogicName = resourceType.LogicName, Name = resourceType.Name };
        }
    }
}