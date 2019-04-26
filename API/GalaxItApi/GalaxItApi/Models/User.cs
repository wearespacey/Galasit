using System.ComponentModel.DataAnnotations;

namespace GalaxItApi.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public byte[] Password { get; set; }
        public Seat Seat { get; set; }
    }
}
