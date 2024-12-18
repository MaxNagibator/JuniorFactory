using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domiki.Web.Data
{
    [Table("DomikTypeLevelModificators")]
    public class DomikTypeLevelModificator
    {
        [Key]
        [Column(Order = 1)]
        public int DomikTypeLevelDomikTypeId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int DomikTypeLevelValue { get; set; }

        [Key]
        [Column(Order = 3)]
        public int ModificatorTypeId { get; set; }

        public int Value { get; set; }

        public DomikTypeLevel DomikTypeLevel { get; set; }

        public ModificatorType ModificatorType { get; set; }
    }
}