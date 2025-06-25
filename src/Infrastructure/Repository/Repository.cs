namespace Infrastructure.Repository
{
    using Domain.Interfaces;
    using Infrastructure.Context;
    using Microsoft.EntityFrameworkCore;

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OracleContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(OracleContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T element)
        {
            await  _dbSet.AddAsync(element);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T element)
        {
            _dbSet.Update(element);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var element = await _dbSet.FindAsync(id);
            if (element != null)
            {
                _dbSet.Remove(element);
                await _context.SaveChangesAsync();
            }
        }
    }
}
