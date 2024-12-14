using ProjetoRPG.Domain.Base;

namespace ProjetoRPG.Service.Base;

public interface IBaseService<T> where T : BaseEntity
{
    Task<T> SaveAsync(T entity);
    Task<List<T>> GetAllAsync();
    IQueryable<T> Get();
    Task<T> GetByIdAsync(int id);
    Task HardDeleteAsync(int id);
    Task RemoveAsync(int id);
}