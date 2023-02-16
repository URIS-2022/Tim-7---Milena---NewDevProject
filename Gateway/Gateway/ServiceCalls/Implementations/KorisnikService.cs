using Gateway.Models.Korisnik;
using Gateway.ServiceCalls.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Gateway.ServiceCalls.Implementations
{
    public class KorisnikService : ServiceCall<KorisnikDto, KorisnikConfirmationDto>, IKorisnikService
    {
        public async Task<KorisnikTokenDto> RegisterAsync(string url, KorisnikDto Dto)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri uri = new Uri(url);
                var request = new HttpRequestMessage(HttpMethod.Post, uri);
                request.Content = new StringContent(JsonConvert.SerializeObject(Dto));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        #pragma warning disable CS8603 // Possible null reference return.
                        return null;
                    }
                    #pragma warning disable CS8603 // Possible null reference return.
                    return JsonConvert.DeserializeObject<KorisnikTokenDto>(content);
                }
                #pragma warning disable CS8603 // Possible null reference return.
                return null;
                #pragma warning restore CS8603 // Possible null reference return.
            }
            catch
            {
                #pragma warning disable CS8603 // Possible null reference return.
                return null;
            }
        }

        public async Task<KorisnikTokenDto> LoginAsync(string url, KorisnikLoginDto Dto)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri uri = new Uri(url);
                var request = new HttpRequestMessage(HttpMethod.Post, uri);
                request.Content = new StringContent(JsonConvert.SerializeObject(Dto));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return null;
                    }
                    return JsonConvert.DeserializeObject<KorisnikTokenDto>(content);
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
