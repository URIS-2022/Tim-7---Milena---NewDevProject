namespace Gateway.ServiceCalls.Interfaces
{
    public interface IServiceCall<T, C> where T: class where C : class
    {
        Task<List<C>> GetAsync(string url);
        Task<C> GetByIdAsync(string url, int id);
        Task<C> PostAsync(string url, T dto);
        Task<C> PutAsync(string url, int? id, T dto);
        Task<C> PutAsync(string url, int? id, C dto);
        Task<string> DeleteAsync(string url, int id);
    }
}
