using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalaxItApi.Models
{
    [Table("Table")]
    public class Table
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public Bubble Bubble { get; set; }

        public IEnumerable<Seat> Seats { get; set; } = new List<Seat>();
    }
}
