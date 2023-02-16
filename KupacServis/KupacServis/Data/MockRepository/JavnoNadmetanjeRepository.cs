using KupacServis.Entities;
using KupacServis.Models.Mock;

namespace KupacServis.Data.MockRepository
{
    public class JavnoNadmetanjeRepository:IJavnoNadmetanjeRepository
    {
        public static List<JavnoNadmetanjeDto> JavnaNadmetanja { get; set; } = new List<JavnoNadmetanjeDto>();

        public JavnoNadmetanjeRepository()
        {
            FillData();
        }

        private void FillData()
        {
            JavnaNadmetanja.AddRange(new List<JavnoNadmetanjeDto>
            {
                new JavnoNadmetanjeDto
                {
                    JavnoNadmetanjeId = Guid.Parse("138AB451-6F31-4069-A2DB-592B2724D211"),
                    Datum = DateTime.Parse("2022-11-15T09:00:00"),
                    VremePocetka= DateTime.Parse("2022-11-15T11:00:00"),
                    VremeKraja=DateTime.Parse("2022-11-16T09:00:00"),
                    PocetnaCenaPoHektaru = 3000,
                    Izuzeto=false,
                    IzlicitiranaCena = 3000000,
                    PeriodZakupa = 2,
                    BrojUcesnika = 300,
                    VisinaDopuneDepozita = 30000,
                    Krug = 1


                },
                new JavnoNadmetanjeDto
                {
                    JavnoNadmetanjeId = Guid.Parse("27641D56-0997-48E2-9EC3-0353AA7925B3"),
                    Datum = DateTime.Parse("2022-11-15T09:00:00"),
                    VremePocetka= DateTime.Parse("2022-11-15T11:00:00"),
                    VremeKraja=DateTime.Parse("2022-11-16T09:00:00"),
                    PocetnaCenaPoHektaru = 4000,
                    Izuzeto=false,
                    IzlicitiranaCena = 4000000,
                    PeriodZakupa = 2,
                    BrojUcesnika = 400,
                    VisinaDopuneDepozita = 40000,
                    Krug = 1
                }
            });
        }

        public List<JavnoNadmetanjeDto> GetJavnaNadmetanja()
        {

            return JavnaNadmetanja.OrderBy(p => p.JavnoNadmetanjeId).ToList();
        }

        
        public JavnoNadmetanjeDto GetJavnoNadmetanjeById(Guid javnoNadmetanjeId)
        {
            return JavnaNadmetanja.FirstOrDefault(e => e.JavnoNadmetanjeId==javnoNadmetanjeId);
        }

    }
}
