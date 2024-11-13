using Microsoft.EntityFrameworkCore;
using ProjetoRPG.Base;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Service.Base;

public abstract class BaseService<T>(IRepBase<T> rep) : IBaseService<T>
    where T : BaseEntity
{
    
    public async Task<List<T>> GetAllAsync()
    {
        return await rep.Get().ToListAsync();
    }

    public IQueryable<T> Get()
    {
        return rep.Get();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await rep.GetByIdAsync(id);
    }
    
    public async Task<T> Save(T entity)
    {
        await rep.SaveAsync(entity);
        return entity;
    }

    public async Task HardDeleteAsync(int id)
    {
        await rep.DeleteAsync(id);
    }

    public async Task RemoveAsync(int id)
    {
        var entity = await rep.GetByIdAsync(id);
        entity.Remove();

        await rep.SaveAsync(entity);
    }
}