namespace Domiki.Web.Business.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogicName { get; set; }

        public Resource[] InputResources { get; set; }
        public int DurationSeconds { get; set; }
        public Resource[] OutputResources { get; set; }
        public int PlodderCount { get; set; }
    }
}