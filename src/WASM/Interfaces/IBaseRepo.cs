namespace WASM.Interfaces;

public interface IBaseRepo<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(string url);
    Task<T> GetByIdAsync(string url, int id);
    Task<bool> CreateAsync(string url, T obj);
    Task<bool> UpdateAsync(string url, T obj);
    Task<bool> DeleteAsync(string url, int id);
}
