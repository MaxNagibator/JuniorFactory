using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Domiki.Web.Data
{
    [Table("Resources")]
    public class Resource
    {
        [Key]
        [Column(Order = 1)]
        public int TypeId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int PlayerId { get; set; }

        public int Value { get; set; }

        public Player Player { get; set; }
    }
}