namespace Application.Interfaces;

public interface IBaseRepo<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    // Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);
    Task<T> GetByIdAsync(int id);
    // Task<T> GetByIdAsync(Expression<Func<T, bool>> filter);
    Task<bool> IsExistsAsync(int id);
    Task<bool> CreateAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<bool> SaveAsync();
}
