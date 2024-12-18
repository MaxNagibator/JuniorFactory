using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domiki.Web.Data
{
    [Table("Players")]
    public class Player
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [MaxLength(450)]
        [Required(AllowEmptyStrings = false)]
        public string AspNetUserId { get; set; }

        [ConcurrencyCheck]
        public Guid Version { get; set; }

        public ICollection<Resource> Resources { get; set; }
    }
}