using Microsoft.EntityFrameworkCore;

namespace UgovorService.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TipGarancije> TipGarancije { get; set; }
        public DbSet<Dokument> Dokument { get; set; }
        public DbSet<Ugovor> Ugovor { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipGarancije>()
               .HasData(
                   new TipGarancije
                   {
                       TipGarancijeID = Guid.Parse("ea44e6b8-269c-4298-a12c-885638095e4f"),
                       NazivTipaG = "Jemstvo"
                   },
                   new TipGarancije
                   {
                       TipGarancijeID = Guid.Parse("8110783f-afbe-4c01-9be7-71de8eb9deff"),
                       NazivTipaG = "Bankarska Garancija"
                   },
                   new TipGarancije
                   {
                       TipGarancijeID = Guid.Parse("8973b944-d7eb-4366-8aa6-e7f9306a0304"),
                       NazivTipaG = "Garancija nekretninom"
                   },
                   new TipGarancije
                   {
                       TipGarancijeID = Guid.Parse("a1885b0e-58f9-4623-92a2-f95bfe0f2fcc"),
                       NazivTipaG = "Žirantska"
                   },
                   new TipGarancije
                   {
                       TipGarancijeID = Guid.Parse("85c389db-cec5-4283-bc47-a042de8785a2"),
                       NazivTipaG = "Uplata gotovinom"
                   }
               );
            modelBuilder.Entity<Dokument>()
                .HasData(
                    new Dokument
                    {
                        DokumentID = Guid.Parse("20980ee8-a44e-4837-bae4-e54a9b6da870"),
                        ZavodniBroj = "ABC-10",
                        Datum = DateTime.Parse("2022-04-21T10:00:00"),
                        DatumDonosenja = DateTime.Parse("2022-04-21T11:00:00"),
                        Sablon = "Odluka o davanju u zakup poljoprivrednog zemljišta"
                    },
                    new Dokument

                    {
                        DokumentID = Guid.Parse("b11ecad0-2655-40d4-93ed-3745e2494bf8"),
                        ZavodniBroj = "ABC-11",
                        Datum = DateTime.Parse("2018-06-11T12:30:00"),
                        DatumDonosenja = DateTime.Parse("2018-06-11T12:30:00"),
                        Sablon = "Odluka o poništenju odluke o davanju u zakup poljoprivrednog zemljišta"
                    },
                    new Dokument
                    {
                        DokumentID = Guid.Parse("1a397c0a-d320-4998-ae39-d137b037cbc0"),
                        ZavodniBroj = "ABC-12",
                        Datum = DateTime.Parse("2020-02-12T13:11:31"),
                        DatumDonosenja = DateTime.Parse("2020-02-12T14:20:00"),
                        Sablon = "Odluka o raspisivanju javnog oglasa za davanje u zakup poljoprivrednog zemljišta u državnoj svojini"
                    },
                    new Dokument
                    {
                        DokumentID = Guid.Parse("8a91ab92-358b-44ae-ba1d-102639f4e738"),
                        ZavodniBroj = "ABC-13",
                        Datum = DateTime.Parse("2023-01-12T10:29:00"),
                        DatumDonosenja = DateTime.Parse("2023-01-12T12:45:00"),
                        Sablon = "Program zaštite, uređenja i korišćenja poljopriverednog zemljišta"
                    },
                    new Dokument
                    {
                        DokumentID = Guid.Parse("364696aa-0369-4af0-954d-21b855b514e4"),
                        ZavodniBroj = "DEF-20",
                        Datum = DateTime.Parse("2023-01-16T15:12:11"),
                        DatumDonosenja = DateTime.Parse("2023-01-17T12:00:25"),
                        Sablon = "Obrazovanje stručne komisije za pregled kvaliteta zemljišta"
                    }
                   
                   
                   
                );

            modelBuilder.Entity<Ugovor>()
                .HasData(
                    new Ugovor
                    {
                        UgovorID = Guid.Parse("50916085-56d4-499c-9321-ae3839c1a4f5"),
                        
                        ZavodniBrojUgovora = "ugovor1",
                        DatumZavodjenja = DateTime.Parse("2022-01-18T16:14:33"),
                        RokZaVracanjeZemljista = DateTime.Parse("2025-07-29T10:00:00"),
                        MestoPotpisa = "Novi Sad",
                        DatumPotpisa = DateTime.Parse("2022-04-23T14:20:57"),
                        TipGarancijeID = Guid.Parse("ea44e6b8-269c-4298-a12c-885638095e4f"),
                        DokumentID = Guid.Parse("20980ee8-a44e-4837-bae4-e54a9b6da870"),
                        JavnoNadmetanjeID = Guid.Parse("525af424-9440-4ee2-8502-01748e13f837"),
                        KupacID = Guid.Parse("ef30d834-a569-4910-aa58-0ddedc4b669d")
                        
                    }
                );
        }
    }
}
