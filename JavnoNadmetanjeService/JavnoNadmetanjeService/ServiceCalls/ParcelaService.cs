using JavnoNadmetanjeService.Models;
using Newtonsoft.Json;

namespace JavnoNadmetanjeService.ServiceCalls
{
    public class ParcelaService:IParcelaService
    {
        private readonly IConfiguration configuration;

        public ParcelaService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<ParcelaInfoDto> GetParcelaById(int ParcelaID)
        {
            using (HttpClient client = new HttpClient())
            {

                Uri url = new Uri($"{configuration["Services:ParcelaService"]}api/Parcela/vo/" + ParcelaID);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseString))
                    {
                        return default;
                    }
                    var parcela = JsonConvert.DeserializeObject<ParcelaInfoDto>(responseString);
                    return parcela;
                }
                return default;

            }
        }
    }
}
