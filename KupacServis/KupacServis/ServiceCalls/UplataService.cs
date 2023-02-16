using KupacServis.Models;
using Newtonsoft.Json;

namespace KupacServis.ServiceCalls
{
    public class UplataService:IUplataService
    {

        private readonly IConfiguration configuration;
        public UplataService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<List<UplataInfoDTO>> GetUplataByKupacID(Guid kupacId)
        {

            using (HttpClient client = new HttpClient())
            {

                Uri url = new Uri($"{configuration["Services:UplataService"]}api/Uplata/" + kupacId);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseString))
                    {
                        return default;
                    }
                    var uplata = JsonConvert.DeserializeObject < List<UplataInfoDTO>>(responseString);
                    return uplata;
                }
                return default;

            }
        }
    }
}
