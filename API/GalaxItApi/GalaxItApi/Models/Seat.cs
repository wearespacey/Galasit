using System;
using System.ComponentModel.DataAnnotations;

namespace GalaxItApi.Models
{
    public class Seat
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public bool Occupied { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [Required]
        public Table Table { get; set; }
    }
}
