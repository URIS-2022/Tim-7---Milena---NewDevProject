using Gateway.ServiceCalls.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Gateway.ServiceCalls.Implementations
{
    public class ServiceCall<T, C> : IServiceCall<T, C> where T : class where C : class
    {
        public async Task<string> DeleteAsync(string url, int id)
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

        public async Task<C> GetByIdAsync(string url, int id)
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

        public async Task<C> PostAsync(string url, T dto)
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
                    return JsonConvert.DeserializeObject<C>(content);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<C> PutAsync(string url, int? id, object dto)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri uri = null;
                if (id == 0)
                    uri = new Uri(url);
                else
                    uri = new Uri(url + id);
                var request = new HttpRequestMessage(HttpMethod.Put, uri);
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
