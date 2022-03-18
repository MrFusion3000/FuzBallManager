namespace Domain.Repositories.Base
{
    public interface IRepository <T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task <T> GetByIdAsync(Guid? id);
        Task <T> AddAsync(T entity);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
