namespace Domiki.Web.Models
{
    public class DomikDto
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int Level { get; set; }
        public DateTime? FinishDate { get; set; }
        public ManufactureDto[] Manufactures { get; set; }
    }
}