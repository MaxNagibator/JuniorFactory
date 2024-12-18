using Domiki.Web.Business.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domiki.Web.Data
{
    [Table("DomikTypeLevelReceipts")]
    public class DomikTypeLevelReceipt
    {
        [Key]
        [Column(Order = 1)]
        public int DomikTypeLevelDomikTypeId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int DomikTypeLevelValue { get; set; }

        [Key]
        [Column(Order = 3)]
        public int ReceiptId { get; set; }

        public DomikTypeLevel DomikTypeLevel { get; set; }

        public Receipt Receipt { get; set; }
    }
}