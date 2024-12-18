using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Domiki.Web.Data
{
    [Table("ReceiptResources")]
    public class ReceiptResource
    {
        [Key]
        [Column(Order = 1)]
        public int ReceiptId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ResourceTypeId { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool IsInput { get; set; } 

        public int Value { get; set; }

        public Receipt Receipt { get; set; }

        public ResourceType ResourceType { get; set; }
    }
}