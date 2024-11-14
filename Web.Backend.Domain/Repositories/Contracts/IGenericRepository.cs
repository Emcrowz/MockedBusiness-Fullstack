namespace Web.Backend.Domain.Repositories.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetSingleAsync(string? id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string? id);
    Task<bool> Exists(string? id);
}