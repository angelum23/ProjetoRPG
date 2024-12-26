using Microsoft.EntityFrameworkCore;
using ProjetoRPG.Domain.Base;
using ProjetoRPG.Infra;

namespace ProjetoRPG.Repository.Base;

public class RepBaseDbSet<TEntity> : IRepBase<TEntity> where TEntity : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _dbSet;
    
    protected RepBaseDbSet(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    
    public IQueryable<TEntity> Get()
    {
        return _dbSet.AsTracking();
    }
    
    public IQueryable<TEntity> GetRemoved()
    {
        return Get().Where(x => x.Removed);
    }
    
    public TEntity GetById(int id)
    {
        var entity = _dbSet.Find(id);

        if (entity == null)
        {
            throw new Exception("Register not found!");
        }

        return entity;
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity == null)
        {
            throw new Exception("Register not found!");
        }

        return entity;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task SaveAsync(TEntity entity)
    {
        if (entity.Id > 0)
        {
            await UpdateAsync(entity);
        }
        else
        {
            await AddAsync(entity);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}