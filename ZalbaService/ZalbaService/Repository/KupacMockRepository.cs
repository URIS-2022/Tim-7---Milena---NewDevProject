using ZalbaService.Entities;
using ZalbaService.Models.Mock;

namespace ZalbaService.Repository
{
    public class KupacMockRepository : IKupacMockRepository
    {
        public static List<KupacDTO> kupci { get; set; } = new List <KupacDTO>();

        public KupacMockRepository()
        {
            FillData();
        }
        private void FillData()
        {
            kupci.AddRange(new List<KupacDTO>
            {
                new KupacDTO
                {
                    KupacId = Guid.Parse("8B88BADB-5EC1-4E38-A90D-C376BC31D011"),
                    PrioritetId = Guid.Parse("2915C26D-2912-438A-BC7A-8ED229009412"),
                    OstvarenaPovrsina = 140000,
                    ImaZabranu = true,
                    DatumPocetkaZabrane = DateTime.Parse("2022-10-15T09:00:00"),
                    DatumPrestankaZabrane = DateTime.Parse("2022-10-25T09:00:00"),
                    DuzinaTrajanjaZabraneUGod = 0,
                    BrRacuna = "08729999",
                    BrTelefona = "00381947294000",
                    Email = "kupacgmail.com"
                },
                new KupacDTO
                {
                    KupacId = Guid.NewGuid(),
                    PrioritetId = Guid.Parse("2915C26D-2912-438A-BC7A-8ED229009412"),
                    OstvarenaPovrsina = 140000,
                    ImaZabranu = true,
                    DatumPocetkaZabrane = DateTime.Parse("2022-10-15T09:00:00"),
                    DatumPrestankaZabrane = DateTime.Parse("2022-10-25T09:00:00"),
                    DuzinaTrajanjaZabraneUGod = 0,
                    BrRacuna = "845128451",
                    BrTelefona = "0653685285",
                    Email = "kupac2gmail.com"
                },

            }
                );
        }
        public KupacDTO GetKupac(Guid KupacID)
        {
            return kupci.FirstOrDefault(e => e.KupacId == KupacID);
        }
    }
}
