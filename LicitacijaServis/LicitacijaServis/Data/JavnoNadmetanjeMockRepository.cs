using LicitacijaServis.Models.Mock;
using Microsoft.EntityFrameworkCore;

namespace LicitacijaServis.Data
{
    public class JavnoNadmetanjeMockRepository : IJavnoNadmetanjeMockRepository
    {
        public static List<JavnoNadmetanjeDto> JavnaNadmetanja { get; set; } = new List<JavnoNadmetanjeDto>();

        public JavnoNadmetanjeMockRepository()
        {
            FillData();
        }

        private void FillData()
        {
            JavnaNadmetanja.AddRange(new List<JavnoNadmetanjeDto>
            {
                new JavnoNadmetanjeDto
                {
                    JavnoNadmetanjeId = Guid.Parse("8A39030B-D50D-422E-80E9-26BA84947DCC"),
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
                     JavnoNadmetanjeId = Guid.Parse("EA18517A-1EBF-495A-8AC5-DD64CEAAF19E"),
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
            return JavnaNadmetanja.FirstOrDefault(e => e.JavnoNadmetanjeId == javnoNadmetanjeId);
        }


    }
}
