using KomisijaURIS.Models;

namespace KomisijaURIS.Data1
{
    public class ClanKomisijeStore
    {
        public static ICollection<ClanKomisijeDto> clanKomisijeDtoList = new List<ClanKomisijeDto>()
        {
            new ClanKomisijeDto{ClanId = 1, ImeClana = "Marko", PrezimeClana = "Petrovic", EmailClana = "markop@gmail.com"},
            new ClanKomisijeDto{ClanId = 2, ImeClana = "Konstantin", PrezimeClana = "Andrejevic", EmailClana = "konstantin@gmail.com"},
            new ClanKomisijeDto{ClanId = 3, ImeClana = "Ana", PrezimeClana = "Lukovic", EmailClana = "ana@gmail.com"}
        };
    }
}
