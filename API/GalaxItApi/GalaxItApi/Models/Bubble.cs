using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalaxItApi.Models
{
    [Table("Bubble")]
    public class Bubble
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Atmosphere { get; set; }

        public IEnumerable<Table> Tables { get; set; } = new List<Table>();
    }
}
