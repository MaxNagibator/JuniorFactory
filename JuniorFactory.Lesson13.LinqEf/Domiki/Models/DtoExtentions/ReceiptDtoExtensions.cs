using Domiki.Web.Business.Models;

namespace Domiki.Web.Models
{
    public static class ReceiptDtoExtensions
    {
        public static ReceiptDto ToDto(this Receipt res)
        {
            return new ReceiptDto
            {
                Id = res.Id,
                Name = res.Name,
                LogicName = res.LogicName,
                InputResources = res.InputResources.Select(x=> x.ToDto()).ToArray(),
                DurationSeconds = res.DurationSeconds,
                OutputResources = res.OutputResources.Select(x => x.ToDto()).ToArray(),
                PlodderCount = res.PlodderCount,
            };
        }
    }
}