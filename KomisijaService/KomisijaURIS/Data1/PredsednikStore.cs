using KomisijaURIS.Models;

namespace KomisijaURIS.Data1
{
    public static class PredsednikStore
    {
        public static ICollection<PredsednikDto> predsednikDtoList = new List<PredsednikDto>
            {
                new PredsednikDto{PredsednikId = 1, ImePredsednika = "Petar", PrezimePredsednika = "Petrovic", EmailPredsednika = "petar@gmail.com"},
                new PredsednikDto{PredsednikId = 2, ImePredsednika = "Ognjen", PrezimePredsednika = "Jovanovic", EmailPredsednika = "ognjen@gmail.com"},
                new PredsednikDto {PredsednikId = 3, ImePredsednika = "Dimitrije", PrezimePredsednika = "Dimitrijevic", EmailPredsednika = "dimitrije@gmail.com" }
            };
    }
}
