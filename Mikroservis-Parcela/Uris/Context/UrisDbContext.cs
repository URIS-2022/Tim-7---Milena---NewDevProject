using Uris.Models;
using Microsoft.EntityFrameworkCore;

namespace Uris.Context
{
    public class UrisDbContext : DbContext
    {
        public UrisDbContext(DbContextOptions<UrisDbContext> options) : base(options)
        { 
        }

        public DbSet<Kultura> Kulture { get; set; }
        public DbSet<KatastarskaOpstina> KatastarskeOpstine { get; set; }
        public DbSet<KvalitetZemljista> KvalitetiZemljista { get; set; }
        public DbSet<Parcela> Parcele { get; set; }
    }
}
