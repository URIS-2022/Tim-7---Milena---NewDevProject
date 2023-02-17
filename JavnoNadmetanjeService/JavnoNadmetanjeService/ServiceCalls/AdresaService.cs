using JavnoNadmetanjeService.Models;
using Newtonsoft.Json;

namespace JavnoNadmetanjeService.ServiceCalls
{
    public class AdresaService : IAdresaService
    {
        private readonly IConfiguration configuration;

        public AdresaService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<AdresaDto> GetAdresaById(Guid AdresaID)
        {
            using (HttpClient client = new HttpClient())
            {

                Uri url = new Uri($"{configuration["Services:AdresaService"]}api/adresa/" + AdresaID);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseString))
                    {
                        return default;
                    }
                    var adresa = JsonConvert.DeserializeObject<AdresaDto>(responseString);
                    return adresa;
                }
                return default;

            }
        }
    }
}
