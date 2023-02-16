using KupacServis.Models;
using Newtonsoft.Json;
namespace KupacServis.ServiceCalls
{
    public class AdresaService:IAdresaService
    {
        private readonly IConfiguration configuration;
        public AdresaService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<AdresaDto> GetAdresaByID(Guid adresaId)
        {
           
            using (HttpClient client = new HttpClient())
            {

                Uri url = new Uri($"{configuration["Services:AdresaService"]}api/adresa/" + adresaId);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseString))
                    {
                        return default;
                    }
                    var kupac = JsonConvert.DeserializeObject<AdresaDto>(responseString);
                    return kupac;
                }
                return default;

            }
        }
    }
}
