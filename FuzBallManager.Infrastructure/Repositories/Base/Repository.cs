using Domain.Repositories.Base;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T: class
    {
        protected readonly FBMContext _FBMContext;
        public Repository(FBMContext FBMContext)
        {
            _FBMContext = FBMContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _FBMContext.Set<T>().AddAsync(entity);
            await _FBMContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _FBMContext.Set<T>().Remove(entity);
            await _FBMContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _FBMContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _FBMContext.Set<T>().FindAsync(id);
        }
        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
