using Gateway.ServiceCalls.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Gateway.ServiceCalls.Implementations
{
    public class ServiceCall<T, C> : IServiceCall<T, C> where T : class where C : class
    {
        public async Task<string> DeleteAsync(string url, object id)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri uri = new Uri(url + id);
                var request = new HttpRequestMessage(HttpMethod.Delete, uri);
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        #pragma warning disable CS8603 // Possible null reference return.
                        return null;
                    }
                    return content;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<C>> GetAsync(string url)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri uri = new Uri(url);
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return null;
                    }
                    return JsonConvert.DeserializeObject<List<C>>(content);
                }
                return null;
            }
            catch 
            {
                return null;
            }
        }

        public async Task<C> GetByIdAsync(string url, object id)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri uri = new Uri(url + id);
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return null;
                    }
                    return JsonConvert.DeserializeObject<C>(content);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<C> PostAsync(string url, T Dto)
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
                    return JsonConvert.DeserializeObject<C>(content);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<C> PutAsync(string url, int? id, object Dto)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri? uri = null;
                if (id == 0)
                    uri = new Uri(url);
                else
                    uri = new Uri(url + id);
                var request = new HttpRequestMessage(HttpMethod.Put, uri);
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
                    return JsonConvert.DeserializeObject<C>(content);
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
