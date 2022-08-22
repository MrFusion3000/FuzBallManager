using Domain.Repositories.Base;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MapsterMapper;

namespace Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T: class
    {
        protected readonly FBMContext _FBMContext;
        //private readonly IMapper _mapper;
        public Repository(FBMContext FBMContext) //, IMapper mapper)
        {
            //_mapper = mapper;
            _FBMContext = FBMContext;
        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _FBMContext.Set<T>().AddAsync(entity, cancellationToken);
            await _FBMContext.SaveChangesAsync(cancellationToken);
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
        public async Task<T> GetByIdAsync(Guid? id)
        {
            return await _FBMContext.Set<T>().FindAsync(id);
        }
        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {           
           _FBMContext.Set<T>().Update(entity);

           await _FBMContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            _FBMContext.Remove(entity);
            await _FBMContext.SaveChangesAsync(cancellationToken);
        }

    }
}
