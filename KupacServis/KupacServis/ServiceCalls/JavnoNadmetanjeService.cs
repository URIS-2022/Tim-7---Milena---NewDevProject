using KupacServis.Models;
using Newtonsoft.Json;

namespace KupacServis.ServiceCalls
{
    public class JavnoNadmetanjeService:IJavnoNadmetanjeService
    {
        private readonly IConfiguration configuration;
        public JavnoNadmetanjeService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<JavnoNadmetanjeInfoDto> GetJavnoNadmetanjeById(Guid javnoNadmetanjeId)
        {
           
            using (HttpClient client = new HttpClient())
            {

                Uri url = new Uri($"{configuration["Services:JavnoNadmetanjeService"]}api/javnoNadmetanje/vo/" + javnoNadmetanjeId);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseString))
                    {
                        return default;
                    }
                    var javnoNadmetanje = JsonConvert.DeserializeObject<JavnoNadmetanjeInfoDto>(responseString);
                    return javnoNadmetanje;
                }
                return default;

            }
        }
    }
}
