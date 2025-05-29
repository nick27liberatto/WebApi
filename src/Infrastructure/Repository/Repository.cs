using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OracleContext _context;
        public Repository(OracleContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Entity entity)
        {
            _context.Entities.Add(entity);
            await  _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.Entities.FindAsync(id);
            if (entity != null)
            {
                _context.Entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _context.Entities.ToListAsync();
        }

        public async Task<Entity?> GetByIdAsync(long id)
        {
            return await _context.Entities.FindAsync(id);
        }

        public async Task UpdateAsync(Entity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
