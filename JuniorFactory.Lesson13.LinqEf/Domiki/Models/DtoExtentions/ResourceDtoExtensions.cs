using Domiki.Web.Business.Models;

namespace Domiki.Web.Models
{
    public static class ResourceDtoExtentions
    {
        public static ResourceDto ToDto(this Resource res)
        {
            return new ResourceDto
            {
                Value = res.Value,
                TypeId = res.Type.Id,
            };
        }
    }
}