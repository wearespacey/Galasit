using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalaxItApi.Models
{
    [Table("Seat")]
    public class Seat
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public bool Occupied { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        //public Table Table { get; set; }

        public IEnumerable<User> Users { get; set; } = new List<User>();
    }
}
