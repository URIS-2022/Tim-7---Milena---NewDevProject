using Microsoft.EntityFrameworkCore;

namespace AdresaService.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Adresa> Adresa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Drzava>()
               .HasData(
                   new Drzava
                   {
                       DrzavaID = Guid.Parse("96bac703-7677-4db3-858c-22b38f34dc19"),
                       NazivDrzave = "Srbija"
                   },
                   new Drzava
                   {
                       DrzavaID = Guid.Parse("61fa9534-5c22-41fd-9517-b0de7eaed1e0"),
                       NazivDrzave = "Crna Gora"
                   },
                   new Drzava
                   {
                       DrzavaID = Guid.Parse("f662cca3-ac7d-42b4-a4a2-97be06d0ca2a"),
                       NazivDrzave = "Madjarska"
                   },
                   new Drzava
                   {
                       DrzavaID = Guid.Parse("0c520e55-4f91-44e4-a647-7ed01e758663"),
                       NazivDrzave = "Hrvatska"
                   },
                   new Drzava
                   {
                       DrzavaID = Guid.Parse("24140a35-74e6-4201-8795-219b89b336d5"),
                       NazivDrzave = "Rumunija"
                   }
               );

            modelBuilder.Entity<Adresa>()
                .HasData(
                    new Adresa
                    {
                        AdresaID = Guid.Parse("c7df55e2-9ddf-408e-9a15-9bc7e309a81f"),
                        Ulica = "Save Kovacevica",
                        Broj = "9",
                        Mesto = "Novi Sad",
                        PostanskiBroj = "21000",
                        DrzavaID = Guid.Parse("96bac703-7677-4db3-858c-22b38f34dc19")
                    },
                    new Adresa

                    {
                        AdresaID = Guid.Parse("bab22d26-811b-4ec1-a012-025102eae6a5"),
                        Ulica = "Jove Pantica",
                        Broj = "19",
                        Mesto = "Podgorica",
                        PostanskiBroj = "22000",
                        DrzavaID = Guid.Parse("61fa9534-5c22-41fd-9517-b0de7eaed1e0")
                    },
                    new Adresa
                    {
                        AdresaID = Guid.Parse("18867358-9ff9-4694-8da9-7719ecad7a51"),
                        Ulica = "Mike Antica",
                        Broj = "4",
                        Mesto = "Split",
                        PostanskiBroj = "23000",
                        DrzavaID = Guid.Parse("0c520e55-4f91-44e4-a647-7ed01e758663")
                    }
                    
                    



                );
















        }
    }
}
