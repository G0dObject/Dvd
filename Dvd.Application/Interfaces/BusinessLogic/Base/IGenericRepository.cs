namespace Dvd.Application.Interfaces.BusinessLogic.Base
{
    public interface IGenericRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task Delete(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<T?> FirstAsync();
        Task<T?> LastAsync();
        Task<List<T>> GetAllAsync();
    }
}
