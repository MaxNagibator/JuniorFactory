using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domiki.Web.Data
{
    [Table("Domiks")]
    public class Domik
    {
        [Key]
        [Column(Order = 1)]
        public int PlayerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int Id { get; set; }

        public int TypeId { get; set; }

        public int Level { get; set; }

        public double? UpgradeSeconds { get; set; }

        public DateTime? UpgradeCalculateDate { get; set; }

        public ICollection<Manufacture> Manufactures { get; set; }
    }
}