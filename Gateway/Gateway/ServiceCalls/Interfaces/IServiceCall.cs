using Gateway.Models;

namespace Gateway.ServiceCalls.Interfaces
{
    public interface IServiceCall<T, C> where T: class where C : class
    {
        Task<ResponsePackageNoData> GetAsync(string url);
        Task<ResponsePackageNoData> GetByIdAsync(string url, object id);
        Task<ResponsePackageNoData> PostAsync(string url, T Dto);
        Task<ResponsePackageNoData> PutAsync(string url, int? id, object Dto);
        Task<string> DeleteAsync(string url, object id);
    }
}
