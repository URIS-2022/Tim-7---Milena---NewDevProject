using Microsoft.EntityFrameworkCore;
using LicitacijaServis.Entities;

namespace LicitacijaServis.Entities
{
    public class LicitacijaContext:DbContext
    {
        public LicitacijaContext(DbContextOptions<LicitacijaContext> options) : base(options)
        {

        }

        public DbSet<Licitacija> Licitacijas { get; set; }

        public DbSet<LicitacijaJavnoNadmetanje> LicitacijaJavnoNadmetanjes { get; set; }



        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Licitacija>().HasKey(k => k.LicitacijaId);
            builder.Entity<LicitacijaJavnoNadmetanje>().HasKey(t => new { t.LicitacijaId, t.JavnoNadmetanjeId });
            builder.Entity<LicitacijaJavnoNadmetanje>().HasOne(k => k.Licitacija)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();



            builder.Entity<Licitacija>(builder =>
            {

                builder.HasData(new Licitacija
                {
                    LicitacijaId = Guid.Parse("FEAD4CEE-FA4C-4B6A-8B27-83B70AA43698"),
                    Broj = 1,
                    Godina = 2022,
                    Ogranicenje = 1000000,
                    KorakCene = 10000,
                    ListaDokumentacijeFizickaLica = "Dokument F1",
                    ListaDokumentacijePravnaLica = "Dokument P1",
                    Rok = DateTime.Parse("2022-10-15T09:00:00"),
                    Datum = DateTime.Parse("2022-10-25T09:00:00"),
                    
                });

                builder.HasData(new Licitacija
                {
                    LicitacijaId = Guid.Parse("9FE2017C-8109-42D9-A7B7-9FF9E016AEFB"),
                    Broj = 2,
                    Godina = 2022,
                    Ogranicenje = 1000000,
                    KorakCene = 10000,
                    ListaDokumentacijeFizickaLica = "Dokument F2",
                    ListaDokumentacijePravnaLica = "Dokument P2",
                    Rok = DateTime.Parse("2022-08-15T09:00:00"),
                    Datum = DateTime.Parse("2022-10-11T09:00:00"),
                    
                });

               
            });

            builder.Entity<LicitacijaJavnoNadmetanje>(builder =>
            {
                builder.HasData(new
                {
                    LicitacijaId = Guid.Parse("9FE2017C-8109-42D9-A7B7-9FF9E016AEFB"),
                    JavnoNadmetanjeId = Guid.Parse("E128D9EA-25D6-47B7-8D94-4B73C6CB536C")
                },
                new
                {
                    LicitacijaId = Guid.Parse("9FE2017C-8109-42D9-A7B7-9FF9E016AEFB"),
                    JavnoNadmetanjeId = Guid.Parse("A21D9035-CC6E-40A6-8FCC-63A3DE6AE448")

                });
            });



        }
    }
}
