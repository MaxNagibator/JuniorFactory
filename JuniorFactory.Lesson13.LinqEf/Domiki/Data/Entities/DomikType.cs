using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domiki.Web.Data
{
    [Table("DomikTypes")]
    public class DomikType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogicName { get; set; }

        public int MaxCount { get; set; }

        public ICollection<DomikTypeLevel> Levels { get; set; }
    }
}