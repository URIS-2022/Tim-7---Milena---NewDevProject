using Korisnik.Entities;
using Microsoft.EntityFrameworkCore;

namespace Korisnik.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<KorisnikEntity> Korisnici { get; set; }
        public DbSet<TipKorisnikaEntity> TipoviKorisnika { get; set; }

    }
}
