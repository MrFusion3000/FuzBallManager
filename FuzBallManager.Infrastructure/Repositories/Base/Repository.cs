using Domain.Repositories.Base;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T: class
    {
        protected readonly PlayerContext _playerContext;
        public Repository(PlayerContext playerContext)
        {
            _playerContext = playerContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _playerContext.Set<T>().AddAsync(entity);
            await _playerContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _playerContext.Set<T>().Remove(entity);
            await _playerContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _playerContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _playerContext.Set<T>().FindAsync(id);
        }
        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
