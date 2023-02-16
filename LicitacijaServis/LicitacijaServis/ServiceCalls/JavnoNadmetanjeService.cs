using LicitacijaServis.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;



namespace LicitacijaServis.ServiceCalls
{
    public class JavnoNadmetanjeService : IJavnoNadmetanjeService
    {
        private readonly IConfiguration configuration;
        public JavnoNadmetanjeService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<JavnoNadmetanjeInfoDto?> GetJavnoNadmetanjeById(Guid javnoNadmetanjeId)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (HttpClient client = new HttpClient(clientHandler))
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
                    var kupac = JsonConvert.DeserializeObject<JavnoNadmetanjeInfoDto>(responseString);
                    return kupac;
                }
                return default;

            }
        }
    }
}
