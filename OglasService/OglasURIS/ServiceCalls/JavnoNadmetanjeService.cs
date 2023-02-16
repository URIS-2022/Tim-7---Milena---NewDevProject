using Newtonsoft.Json;
using OglasURIS.DTO;

namespace OglasURIS.ServiceCalls
{
    public class JavnoNadmetanjeService : IJavnoNadmetanjeService
    {
        private readonly IConfiguration configuration;

        public JavnoNadmetanjeService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<JavnoNadmetanjeInfoDto> GetJavnoNadmetanjeById(Guid JavnoNadmetanjeId)
        {
            using (HttpClient client = new HttpClient())
            {

                Uri url = new Uri($"{configuration["Services:JavnoNadmetanjeService"]}api/javnoNadmetanje/vo/" + JavnoNadmetanjeId);
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
