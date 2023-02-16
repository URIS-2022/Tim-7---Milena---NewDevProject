using Microsoft.EntityFrameworkCore;
using Mikroservis_Uplata.Models;

namespace Mikroservis_Uplata.Context
{
    public class UrisDbContext : DbContext
    {
        public UrisDbContext(DbContextOptions<UrisDbContext> options) : base(options)
        {
        }

        public DbSet<Uplata> Uplate { get; set; }
        public DbSet<Kurs> Kursevi { get; set; }

    }
}
