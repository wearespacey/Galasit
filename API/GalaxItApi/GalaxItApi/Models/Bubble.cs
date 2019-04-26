using System.ComponentModel.DataAnnotations;

namespace GalaxItApi.Models
{
    public class Bubble
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string Atmosphere { get; set; }
    }
}
