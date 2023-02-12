using Gateway.Models.Korisnik;
using Gateway.ServiceCalls.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Gateway.ServiceCalls.Implementations
{
    public class KorisnikService : ServiceCall<KorisnikDTO, KorisnikConfirmationDTO>, IKorisnikService
    {
        public async Task<KorisnikTokenDTO> RegisterAsync(string url, KorisnikDTO dto)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri uri = new Uri(url);
                var request = new HttpRequestMessage(HttpMethod.Post, uri);
                request.Content = new StringContent(JsonConvert.SerializeObject(dto));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return null;
                    }
                    return JsonConvert.DeserializeObject<KorisnikTokenDTO>(content);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<KorisnikTokenDTO> LoginAsync(string url, KorisnikLoginDTO dto)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri uri = new Uri(url);
                var request = new HttpRequestMessage(HttpMethod.Post, uri);
                request.Content = new StringContent(JsonConvert.SerializeObject(dto));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return null;
                    }
                    return JsonConvert.DeserializeObject<KorisnikTokenDTO>(content);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
