namespace Domiki.Web.Models
{
    public class ReceiptDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogicName { get; set; }

        public ResourceDto[] InputResources { get; set; }
        public int DurationSeconds { get; set; }
        public ResourceDto[] OutputResources { get; set; }
        public int PlodderCount { get; set; }
    }
}