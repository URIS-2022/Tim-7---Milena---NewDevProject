using KupacServis.Models.Mock;

namespace KupacServis.Data.MockRepository
{
    public class UplataRepository:IUplataRepository
    {
        public static List<UplataDto> Uplate { get; set; } = new List<UplataDto>();

        public UplataRepository()
        {
            FillData();
        }

        private void FillData()
        {
            Uplate.AddRange(new List<UplataDto>
            {
                new UplataDto
                {
                    UplataId = Guid.Parse("82FB045B-D995-4313-81D6-50435F103F77"),
                    BrojRacuna = "21345",
                    PozivNaBroj="996",
                    Iznos=3000,
                    SvrhaUplate = "Ovjera semestra",
                    Datum = DateTime.Parse("2022-11-15T11:00:00")

                },
                new UplataDto
                {
                    UplataId = Guid.Parse("7AF4160F-9D0D-423D-87E8-D89E1B3D552D"),
                    BrojRacuna = "21000",
                    PozivNaBroj="956",
                    Iznos=9000,
                    SvrhaUplate = "Ovjera semestra",
                    Datum = DateTime.Parse("2022-11-15T11:00:00")
                }
            });
        }

        public List<UplataDto> GetUplata()
        {

            return Uplate.OrderBy(p => p.UplataId).ToList();
        }

        public UplataDto GetUplataById(Guid uplataId)
        {
            return Uplate.FirstOrDefault(e => e.UplataId == uplataId);
        }
    }
}
