using JavnoNadmetanjeService.Models;
using Newtonsoft.Json;

namespace JavnoNadmetanjeService.ServiceCalls
{
    public class OvlascenoLiceService : IOvlascenoLiceService
    {
        private readonly IConfiguration configuration;
        public OvlascenoLiceService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<OvlascenoLiceInfoDto> GetOvlascenoLiceById(Guid OvlascenoLiceID)
        {
            using (HttpClient client = new HttpClient())
            {

                Uri url = new Uri($"{configuration["Services:KupacService"]}api/ovlascenoLice/vo/" + OvlascenoLiceID);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseString))
                    {
                        return default;
                    }
                    var ovlascenoLice = JsonConvert.DeserializeObject<OvlascenoLiceInfoDto>(responseString);

                    return ovlascenoLice;
                }
                return default;

            }
        }
    }
}
