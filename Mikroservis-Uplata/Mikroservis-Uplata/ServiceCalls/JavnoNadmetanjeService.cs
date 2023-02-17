using Mikroservis_Uplata.DTO;
using Newtonsoft.Json;

namespace Mikroservis_Uplata.ServiceCalls
{
    public class JavnoNadmetanjeService : IJavnoNadmetanjeService
    {
        private readonly IConfiguration configuration;
        public JavnoNadmetanjeService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<JavnoNadmetanjeDto> GetJavnoNadmetanjeById(Guid JavnoNadmetanjeID)
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
                    var javnoNadmetanje = JsonConvert.DeserializeObject<JavnoNadmetanjeDto>(responseString);
                    return javnoNadmetanje;
                }
                return default;

            }
        }
    }
}
