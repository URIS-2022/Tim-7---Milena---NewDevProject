
using Microsoft.EntityFrameworkCore;
using System;
using KupacServis.Models;

namespace KupacServis.Entities
{
    public class KupacContext : DbContext
    {
        public KupacContext(DbContextOptions<KupacContext> options) : base(options)
        {
        }

        public DbSet<Prioritet> Prioritets { get; set; }

        public DbSet<Kupac> Kupacs { get; set; }

        public DbSet<PravnoLice> PravnoLices { get; set; }

        public DbSet<FizickoLice> FizickoLices { get; set; }

        public DbSet<OvlascenoLice> OvlascenoLices { get; set; }

        public DbSet<KupacOvlascenoLice> KupacOvlascenoLices { get; set; }
        public DbSet<KupacJavnoNadmetanje> KupacJavnoNadmetanjes { get; set; }

       


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PravnoLice>()
                .HasKey(t => new { t.PravnoLiceId, t.KupacId });

            builder.Entity<FizickoLice>()
                .HasKey(t => new { t.FizickoLiceId, t.KupacId });

            builder.Entity<Kupac>().HasKey(t => t.KupacId);

            builder.Entity<KupacOvlascenoLice>().HasKey(t => new { t.KupacId, t.OvlascenoLiceId });

           builder.Entity<KupacOvlascenoLice>()
                .HasOne(p => p.Kupac)
                .WithMany()
                .HasForeignKey(p => p.KupacId);

            builder.Entity<KupacOvlascenoLice>()
                .HasOne(p => p.OvlascenoLice)
                .WithMany()
                .HasForeignKey(p => p.OvlascenoLiceId);


            builder.Entity<KupacJavnoNadmetanje>().HasKey(t => new { t.KupacId, t.JavnoNadmetanjeId });
            builder.Entity<KupacJavnoNadmetanje>()
               .HasOne(k => k.Kupac)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();


            builder.Entity<Prioritet>(builder =>
            {
                builder.HasData(new Prioritet
                {
                    PrioritetId = Guid.Parse("2915C26D-2912-438A-BC7A-8ED229009412"),
                    OpisPrioriteta = "Prvi"
                });

                builder.HasData(new Prioritet
                {
                    PrioritetId = Guid.Parse("C555941C-1913-4E0D-946D-A12E2B18C606"),
                    OpisPrioriteta = "Drugi"
                });


            });

            builder.Entity<Kupac>(builder =>
            {

                builder.HasData(new Kupac
                {
                    KupacId = Guid.Parse("FEAD4CEE-FA4C-4B6A-8B27-83B70AA43698"),
                    PrioritetId = Guid.Parse("2915C26D-2912-438A-BC7A-8ED229009412"),
                    OstvarenaPovrsina = 100000,
                    ImaZabranu = true,
                    DatumPocetkaZabrane = DateTime.Parse("2022-10-15T09:00:00"),
                    DatumPrestankaZabrane = DateTime.Parse("2022-10-25T09:00:00"),
                    DuzinaTrajanjaZabraneUGod = 0,
                    BrRacuna = "08728918",
                    BrTelefona1 = "00381947294038",
                    BrTelefona2 = "00381987627389",
                    Email = "kupac1@gmail.com",
                   

                });

                builder.HasData(new Kupac
                {
                    KupacId = Guid.Parse("9FE2017C-8109-42D9-A7B7-9FF9E016AEFB"),
                    PrioritetId = Guid.Parse("C555941C-1913-4E0D-946D-A12E2B18C606"),
                    OstvarenaPovrsina = 140000,
                    ImaZabranu = true,
                    DatumPocetkaZabrane = DateTime.Parse("2022-10-15T09:00:00"),
                    DatumPrestankaZabrane = DateTime.Parse("2022-10-25T09:00:00"),
                    DuzinaTrajanjaZabraneUGod = 0,
                    BrRacuna = "08729999",
                    BrTelefona1 = "00381947294000",
                    BrTelefona2 = "00381987627111",
                    Email = "kupac2@gmail.com",
                   

                }, new
                {
                    KupacId = Guid.Parse("5E8B59B3-14C6-417A-BFDC-378F617A5EF4"),
                    PrioritetId = Guid.Parse("C555941C-1913-4E0D-946D-A12E2B18C606"),
                    OstvarenaPovrsina = 1890000,
                    ImaZabranu = true,
                    DatumPocetkaZabrane = DateTime.Parse("2021-10-12T09:00:00"),
                    DatumPrestankaZabrane = DateTime.Parse("2023-10-15T09:00:00"),
                    DuzinaTrajanjaZabraneUGod = 2,
                    BrRacuna = "R6676390",
                    BrTelefona1 = "00381947294789",
                    BrTelefona2 = "00381987622265",
                    Email = "kupac3@gmail.com",

                });
            });

            builder.Entity<PravnoLice>(builder =>
            {
                builder.HasData(new PravnoLice
                {
                    PravnoLiceId = Guid.Parse("83E1CD66-5610-4005-B742-6402D684D8A1"),
                    Naziv = "PravnoLice1",
                    MaticniBroj = "12345678",
                    Faks = "3456",
                    KupacId = Guid.Parse("9FE2017C-8109-42D9-A7B7-9FF9E016AEFB")

                });


            });
            builder.Entity<FizickoLice>(builder =>
            {
                builder.HasData(new FizickoLice
                {
                    FizickoLiceId = Guid.Parse("C15EE1BC-0D86-48F8-973A-D9284FAFE2D8"),
                    Ime = "Marko",
                    Prezime = "Markovic",
                    JMBG = "1402993879899",
                    KupacId = Guid.Parse("FEAD4CEE-FA4C-4B6A-8B27-83B70AA43698")

                }, new
                {
                    FizickoLiceId = Guid.Parse("5B902B20-5F5C-40DB-AE32-DC95DD948419"),
                    Ime = "Jelena",
                    Prezime = "Matic",
                    JMBG = "0908991456754",
                    KupacId = Guid.Parse("5E8B59B3-14C6-417A-BFDC-378F617A5EF4")

                });


            });
            builder.Entity<OvlascenoLice>(builder =>
            {
                builder.HasData(new OvlascenoLice
                {
                    OvlascenoLiceId = Guid.Parse("1A6290EC-EAEF-45A2-A01A-447ED04D6565"),
                    Ime = "Marko",
                    Prezime = "Janic",
                    Jmbg = "123456786543224",
                    AdresaId = Guid.Parse("7349C655-8C0D-4743-8F24-8E8B6EEED64B"),
                    DrzavaId=Guid.Parse("95C78CC7-745E-4946-BF7E-1CEE81F24F36"),
                    BrTable=8889

                });


            });
            builder.Entity<KupacJavnoNadmetanje>()
                .HasData(new
                {
                    KupacId =Guid.Parse("9FE2017C-8109-42D9-A7B7-9FF9E016AEFB"),
                    JavnoNadmetanjeId=Guid.Parse("E128D9EA-25D6-47B7-8D94-4B73C6CB536C")

                }, new {
                   KupacId = Guid.Parse("9FE2017C-8109-42D9-A7B7-9FF9E016AEFB"),
                   JavnoNadmetanjeId = Guid.Parse("138AB451-6F31-4069-A2DB-592B2724D211")

               });

            builder.Entity<KupacOvlascenoLice>(builder =>
            {
                builder.HasData(new KupacOvlascenoLice
                {
                    KupacId = Guid.Parse("9FE2017C-8109-42D9-A7B7-9FF9E016AEFB"),
                    OvlascenoLiceId = Guid.Parse("1A6290EC-EAEF-45A2-A01A-447ED04D6565")

                });


            });


        }

       

    }




    
}
