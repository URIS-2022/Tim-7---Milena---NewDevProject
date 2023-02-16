using Microsoft.EntityFrameworkCore;

namespace JavnoNadmetanjeService.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TipJavnogNadmetanja> TipJavnogNadmetanja { get; set; }
        public DbSet<StatusJavnogNadmetanja> StatusJavnogNadmetanja { get; set; }
        public DbSet<JavnoNadmetanje> JavnoNadmetanje { get; set; }
        public DbSet<JavnoNadmetanjePrijavljeniKupci> JavnoNadmetanjePrijavljeniKupci { get; set; }
        public DbSet<JavnoNadmetanjeOvlascenaLica> JavnoNadmetanjeOvlascenaLica { get; set; }
        public DbSet<JavnoNadmetanjeParcele> JavnoNadmetanjeParcele { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JavnoNadmetanjePrijavljeniKupci>()
                .HasKey(jn => new { jn.JavnoNadmetanjeID, jn.KupacID });
            modelBuilder.Entity<JavnoNadmetanjePrijavljeniKupci>()
                .HasOne(jn => jn.JavnoNadmetanje)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<JavnoNadmetanjeOvlascenaLica>()
                .HasKey(jn => new { jn.JavnoNadmetanjeID, jn.OvlascenoLiceID });
            modelBuilder.Entity<JavnoNadmetanjeOvlascenaLica>()
                .HasOne(jn => jn.JavnoNadmetanje)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<JavnoNadmetanjeParcele>()
                .HasKey(jn => new { jn.JavnoNadmetanjeID, jn.ParcelaID });
            modelBuilder.Entity<JavnoNadmetanjeParcele>()
                .HasOne(jn => jn.JavnoNadmetanje)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<TipJavnogNadmetanja>()
               .HasData(new
               {
                   TipJavnogNadmetanjaID = Guid.Parse("97DCA59E-49DF-468C-83F6-2171A966D3BB"),
                   NazivTipaJavnogNadmetanja = "Javna licitacija"
               });
            modelBuilder.Entity<TipJavnogNadmetanja>()
                .HasData(new
                {
                    TipJavnogNadmetanjaID = Guid.Parse("B54D76E0-A230-4821-A072-E40524766D77"),
                    NazivTipaJavnogNadmetanja = "Otvaranje zatvorenih ponuda"
                });
            modelBuilder.Entity<StatusJavnogNadmetanja>()
              .HasData(new
              {
                  StatusJavnogNadmetanjaID = Guid.Parse("9E2D4DAC-D491-46C3-A0C5-3437CB4E6CB4"),
                  NazivStatusaJavnogNadmetanja = "Prvi krug"
              });
            modelBuilder.Entity<StatusJavnogNadmetanja>()
                .HasData(new
                {
                    StatusJavnogNadmetanjaID = Guid.Parse("BD094186-09D6-4C8E-AF79-ABEEEE94BA8A"),
                    NazivStatusaJavnogNadmetanja = "Drugi krug sa starim uslovima"
                });
            modelBuilder.Entity<JavnoNadmetanje>()
                .HasData(new
                {
                    JavnoNadmetanjeID = Guid.Parse("E128D9EA-25D6-47B7-8D94-4B73C6CB536C"),
                    Datum = DateTime.Parse("2023-02-05"),
                    VremePocetka = "10:00:00",
                    VremeKraja = "14:00:00",
                    PocetnaCenaPoHektaru = 1000,
                    Izuzeto = false,
                    TipJavnogNadmetanjaID = Guid.Parse("B54D76E0-A230-4821-A072-E40524766D77"),
                    StatusJavnogNadmetanjaID = Guid.Parse("9E2D4DAC-D491-46C3-A0C5-3437CB4E6CB4"),
                    IzlicitiranaCena = 2500,
                    PeriodZakupa = 5,
                    BrojUcesnika = 10,
                    VisinaDopuneDepozita = 200,
                    Krug = 1,
                    KupacID = Guid.Parse("9FE2017C-8109-42D9-A7B7-9FF9E016AEFB"),
                    AdresaID = Guid.Parse("c7df55e2-9ddf-408e-9a15-9bc7e309a81f")
                });
            modelBuilder.Entity<JavnoNadmetanje>()
                .HasData(new
                {
                    JavnoNadmetanjeID = Guid.Parse("A21D9035-CC6E-40A6-8FCC-63A3DE6AE448"),
                    Datum = DateTime.Parse("2023-02-06"),
                    VremePocetka = "11:00:00",
                    VremeKraja = "15:00:00",
                    PocetnaCenaPoHektaru = 800,
                    Izuzeto = false,
                    TipJavnogNadmetanjaID = Guid.Parse("B54D76E0-A230-4821-A072-E40524766D77"),
                    StatusJavnogNadmetanjaID = Guid.Parse("9E2D4DAC-D491-46C3-A0C5-3437CB4E6CB4"),
                    IzlicitiranaCena = 1600,
                    PeriodZakupa = 4,
                    BrojUcesnika = 5,
                    VisinaDopuneDepozita = 300,
                    Krug = 2,
                    KupacID = Guid.Parse("FEAD4CEE-FA4C-4B6A-8B27-83B70AA43698"),
                    AdresaID = Guid.Parse("bab22d26-811b-4ec1-a012-025102eae6a5")
                });
            modelBuilder.Entity<JavnoNadmetanjePrijavljeniKupci>()
                .HasData(new
                {
                    JavnoNadmetanjeID = Guid.Parse("A21D9035-CC6E-40A6-8FCC-63A3DE6AE448"),
                    KupacID = Guid.Parse("FEAD4CEE-FA4C-4B6A-8B27-83B70AA43698")
                },
                new
                {
                    JavnoNadmetanjeID = Guid.Parse("A21D9035-CC6E-40A6-8FCC-63A3DE6AE448"),
                    KupacID = Guid.Parse("9FE2017C-8109-42D9-A7B7-9FF9E016AEFB")
                });
            modelBuilder.Entity<JavnoNadmetanjeOvlascenaLica>()
                .HasData(new
                {
                    JavnoNadmetanjeID = Guid.Parse("A21D9035-CC6E-40A6-8FCC-63A3DE6AE448"),
                    OvlascenoLiceID = Guid.Parse("87AE40CF-A971-434E-ACD7-8E7F522433F9")
                },
                new
                {
                    JavnoNadmetanjeID = Guid.Parse("A21D9035-CC6E-40A6-8FCC-63A3DE6AE448"),
                    OvlascenoLiceID = Guid.Parse("A1030C3B-9552-4946-A54E-559BED8CF733")
                });
            modelBuilder.Entity<JavnoNadmetanjeParcele>()
                .HasData(new
                {
                    JavnoNadmetanjeID = Guid.Parse("A21D9035-CC6E-40A6-8FCC-63A3DE6AE448"),
                    ParcelaID = 1
                },
                new
                {
                    JavnoNadmetanjeID = Guid.Parse("A21D9035-CC6E-40A6-8FCC-63A3DE6AE448"),
                    ParcelaID = 2
                });


        }

        }
}
