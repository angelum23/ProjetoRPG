

using ProjetoRPG.Domain.Base;

namespace ProjetoRPG.Repository.Base;

public interface IRepBase<TEntity> where TEntity : BaseEntity
{
    public IQueryable<TEntity> Get();
    public IQueryable<TEntity> GetRemoved();
    public TEntity GetById(int id);
    public Task<TEntity> GetByIdAsync(int id);
    public Task AddAsync(TEntity entity);
    public Task UpdateAsync(TEntity entity);
    public Task SaveAsync(TEntity entity);
    public Task DeleteAsync(int id);
}