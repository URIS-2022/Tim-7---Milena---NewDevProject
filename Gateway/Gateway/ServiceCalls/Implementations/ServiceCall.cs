using Gateway.Models;
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
                Uri uri = new(url + id);
                var request = new HttpRequestMessage(HttpMethod.Delete, uri);
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        #pragma warning disable CS8603 // Possible null reference return.
                        return "Empty response";
                    }
                    return content;
                }
                return "Bad request";
            }
            catch
            {
                return "No connection could be made because the target machine actively refused it";
            }
        }

        public async Task<ResponsePackageNoData> GetAsync(string url)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri uri = new(url);
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return new ResponsePackageNoData(StatusCodes.Status204NoContent, "Empty response");
                    }
                    return new ResponsePackageList<C>(JsonConvert.DeserializeObject<List<C>>(content)!);
                }
                return new ResponsePackageNoData(StatusCodes.Status400BadRequest, "Bad request");
            }
            catch 
            {
                var error = new ResponsePackageNoData
                {
                    Message = "No connection could be made because the target machine actively refused it",
                    Status = StatusCodes.Status500InternalServerError
                };
                return error;
            }
        }

        public async Task<ResponsePackageNoData> GetByIdAsync(string url, object id)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri uri = new(url + id);
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return new ResponsePackageNoData(StatusCodes.Status204NoContent, "Empty response");
                    }
                    return new ResponsePackage<C>(JsonConvert.DeserializeObject<C>(content)!);
                }
                return new ResponsePackageNoData(StatusCodes.Status400BadRequest, "Bad request");
            }
            catch
            {
                var error = new ResponsePackageNoData
                {
                    Message = "No connection could be made because the target machine actively refused it",
                    Status = StatusCodes.Status500InternalServerError
                };
                return error;
            }
        }

        public async Task<ResponsePackageNoData> PostAsync(string url, T Dto)
        {
            try
            {
                using var httpClient = new HttpClient();
                Uri uri = new(url);
                var request = new HttpRequestMessage(HttpMethod.Post, uri);
                request.Content = new StringContent(JsonConvert.SerializeObject(Dto));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return new ResponsePackageNoData(StatusCodes.Status204NoContent, "Empty response");
                    }
                    return new ResponsePackage<C>(JsonConvert.DeserializeObject<C>(content)!);
                }
                return new ResponsePackageNoData(StatusCodes.Status400BadRequest, "Bad request");
            }
            catch
            {
                var error = new ResponsePackageNoData
                {
                    Message = "No connection could be made because the target machine actively refused it",
                    Status = StatusCodes.Status500InternalServerError
                };
                return error;
            }
        }

        public async Task<ResponsePackageNoData> PutAsync(string url, int? id, object Dto)
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
                        return new ResponsePackageNoData(StatusCodes.Status204NoContent, "Empty response");
                    }
                    return new ResponsePackage<C>(JsonConvert.DeserializeObject<C>(content)!);
                }
                return new ResponsePackageNoData(StatusCodes.Status400BadRequest, "Bad request");
            }
            catch
            {
                var error = new ResponsePackageNoData
                {
                    Message = "No connection could be made because the target machine actively refused it",
                    Status = StatusCodes.Status500InternalServerError
                };
                return error;
            }
        }
    }
}
