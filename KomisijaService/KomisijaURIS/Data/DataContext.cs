using KomisijaURIS.Entites;
using Microsoft.EntityFrameworkCore;

namespace KomisijaURIS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Predsednik> Predsednici { get; set; }
        public DbSet<ClanKomisije> ClanoviKomisije { get; set; }
        public DbSet<Komisija> Komisije { get; set; }
    }
}
