using Domiki.Web.Business.Models;

namespace Domiki.Web.Models
{
    public static class ModificatorDtoExtentions
    {
        public static ModificatorDto ToDto(this Modificator res)
        {
            return new ModificatorDto
            {
                Value = res.Value,
                TypeId = res.Type.Id,
            };
        }
    }
}