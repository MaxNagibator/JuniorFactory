using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domiki.Web.Data
{
    [Table("ResourceTypes")]
    public class ResourceType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string LogicName { get; set; }
    }
}