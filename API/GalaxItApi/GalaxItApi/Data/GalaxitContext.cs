using GalaxItApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GalaxItApi.Data
{
    public class GalaxitContext : DbContext
    {
        public GalaxitContext(DbContextOptions<GalaxitContext> options): base(options)
        {}
        public DbSet<Bubble> Bubbles { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
