using KupacServis.Models;
using Newtonsoft.Json;

namespace KupacServis.ServiceCalls
{
    public class DrzavaService:IDrzavaService
    {
        private readonly IConfiguration configuration;
        public DrzavaService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<DrzavaDto> GetDrzavaByID(Guid drzavaId)
        {

            using (HttpClient client = new HttpClient())
            {

                Uri url = new Uri($"{configuration["Services:DrzavaService"]}api/drzava/" + drzavaId);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseString))
                    {
                        return default;
                    }
                    var drzava = JsonConvert.DeserializeObject<DrzavaDto>(responseString);
                    return drzava;
                }
                return default;

            }
        }
    }
}
