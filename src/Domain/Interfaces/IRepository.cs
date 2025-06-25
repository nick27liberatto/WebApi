using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T element);
        Task UpdateAsync(T element);
        Task DeleteAsync(int id);
    }
}
