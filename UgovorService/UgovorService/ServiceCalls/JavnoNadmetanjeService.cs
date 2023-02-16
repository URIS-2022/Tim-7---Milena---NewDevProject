using Newtonsoft.Json;
using UgovorService.Models;

namespace UgovorService.ServiceCalls
{
    public class JavnoNadmetanjeService : IJavnoNadmetanjeService
    {
        private readonly IConfiguration configuration;
        public JavnoNadmetanjeService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<JavnoNadmetanjeInfoDTO> GetJavnoNadmetanjeById(Guid JavnoNadmetanjeID)
        {
            using (HttpClient client = new HttpClient())
            {

                Uri url = new Uri($"{configuration["Services:JavnoNadmetanjeService"]}api/javnoNadmetanje/vo/" + JavnoNadmetanjeID);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseString))
                    {
                        return default;
                    }
                    var javnoNadmetanje = JsonConvert.DeserializeObject<JavnoNadmetanjeInfoDTO>(responseString);
                    return javnoNadmetanje;
                }
                return default;

            }
        }
    }
}
