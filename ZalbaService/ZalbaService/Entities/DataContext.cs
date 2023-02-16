using Microsoft.EntityFrameworkCore;

namespace ZalbaService.Entities

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TipZalbe> TipZalbe { get; set; }
        public DbSet<StatusZalbe> StatusZalbe { get; set; }
        public DbSet<RadnjaNaOsnovuZalbe> RadnjaNaOsnovuZalbe { get; set; }
        public DbSet<Zalba> Zalba { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipZalbe>()
               .HasData(new 
               {
                   TipZalbeID = Guid.Parse("9D51BFEC-5281-4972-970D-B3BB2119E9ED"),
                   NazivTipaZalbe = "Žalba na tok javnog nadmetanja"
               });
            modelBuilder.Entity<TipZalbe>()
                .HasData(new 
                {
                    TipZalbeID = Guid.Parse("D5D6624E-48F6-4167-BB07-9E8589FD9281"),
                    NazivTipaZalbe = "Žalba na Odluku o davanju u zakup"
                });
            modelBuilder.Entity<StatusZalbe>()
               .HasData(new 
               {
                   StatusZalbeID = Guid.Parse("8D2CE4F7-C2A2-40F1-A92E-F30AC529153E"),
                   NazivStatusaZalbe = "Usvojena"
               });
            modelBuilder.Entity<StatusZalbe>()
                .HasData(new 
                {
                    StatusZalbeID = Guid.Parse("5B3470DA-A635-4A04-8EF4-988608C46546"),
                    NazivStatusaZalbe = "Odbijena"
                });

            modelBuilder.Entity<RadnjaNaOsnovuZalbe>()
               .HasData(new
               {
                   RadnjaNaOsnovuZalbeID = Guid.Parse("55C00A00-BA2B-4141-966C-5CFB5EA50079"),
                   NazivRadnjeNaOsnovuZalbe = "JN ide u drugi krug sa novim uslovima"
               });
            modelBuilder.Entity<RadnjaNaOsnovuZalbe>()
                .HasData(new
                {
                    RadnjaNaOsnovuZalbeID = Guid.Parse("AF98278E-4A44-462F-9978-460B1AB8E2D1"),
                    NazivRadnjeNaOsnovuZalbe = "JN ne ide u drugi krug"
                });
            modelBuilder.Entity<Zalba>()
                .HasData(new
                {
                    ZalbaID = Guid.Parse("B787E1FE-01AA-4AEE-A153-0A0ACCE216A6"),
                    DatumPodnosenjaZalbe = DateTime.Parse("2023-02-01T00:10:54"),
                    RazlogZalbe = "Razlog žalbe",
                    Obrazlozenje = "Obrazloženje odluke",
                    BrojNadmetanja = "Br.nadmetanja-01",
                    DatumResenja = DateTime.Parse("2023-02-01T12:10:54"),
                    BrojResenja = "Br.rešenja-001",
                    TipZalbeID = Guid.Parse("9D51BFEC-5281-4972-970D-B3BB2119E9ED"),
                    StatusZalbeID = Guid.Parse("8D2CE4F7-C2A2-40F1-A92E-F30AC529153E"),
                    RadnjaNaOsnovuZalbeID = Guid.Parse("55C00A00-BA2B-4141-966C-5CFB5EA50079"),
                    PodnosilacZalbeID = Guid.Parse("8B88BADB-5EC1-4E38-A90D-C376BC31D011")

                });

            modelBuilder.Entity<Zalba>()
                .HasData(new
                {
                    ZalbaID = Guid.Parse("585AC17B-2267-46DE-83B0-F4E5C45BC178"),
                    DatumPodnosenjaZalbe = DateTime.Parse("2023-01-02T10:10:54"),
                    RazlogZalbe = "Razlog žalbe",
                    Obrazlozenje = "Obrazloženje odluke",
                    BrojNadmetanja = "Br.nadmetanja-01",
                    DatumResenja = DateTime.Parse("2023-02-02T14:10:54"),
                    BrojResenja = "Br.rešenja-001",
                    TipZalbeID = Guid.Parse("9D51BFEC-5281-4972-970D-B3BB2119E9ED"),
                    StatusZalbeID = Guid.Parse("8D2CE4F7-C2A2-40F1-A92E-F30AC529153E"),
                    RadnjaNaOsnovuZalbeID = Guid.Parse("55C00A00-BA2B-4141-966C-5CFB5EA50079"),
                    PodnosilacZalbeID = Guid.Parse("8B88BADB-5EC1-4E38-A90D-C376BC31D011")

                });
        }



        }
}
