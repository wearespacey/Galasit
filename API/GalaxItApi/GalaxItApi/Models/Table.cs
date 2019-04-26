using System.ComponentModel.DataAnnotations;

namespace GalaxItApi.Models
{
    public class Table
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public Bubble Bubble { get; set; }
    }
}
