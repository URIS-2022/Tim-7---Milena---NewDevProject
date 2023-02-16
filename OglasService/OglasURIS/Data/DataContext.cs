using Microsoft.EntityFrameworkCore;
using OglasURIS.Models;

namespace OglasURIS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Oglas> Oglasi { get; set; }
        public DbSet<SluzbeniList> SluzbeniListovi { get; set; }
        
    }
}
