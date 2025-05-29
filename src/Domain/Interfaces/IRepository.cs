using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<Entity?> GetByIdAsync(long id);
        Task AddAsync(Entity entity);
        Task UpdateAsync(Entity entity);
        Task DeleteAsync(long id);
    }
}
