namespace Gateway.ServiceCalls.Interfaces
{
    public interface IServiceCall<T, C> where T: class where C : class
    {
        Task<List<C>> GetAsync(string url);
        Task<C> GetByIdAsync(string url, object id);
        Task<C> PostAsync(string url, T Dto);
        Task<C> PutAsync(string url, int? id, object Dto);
        Task<string> DeleteAsync(string url, object id);
    }
}
