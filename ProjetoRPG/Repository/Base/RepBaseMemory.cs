using ProjetoRPG.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRPG.Repository.Base
{
    public class RepBaseMemory<TEntity> : IRepBase<TEntity> where TEntity : BaseEntity
    {
        private readonly List<TEntity> _list = new();

        public IQueryable<TEntity> Get()
        {
            return _list.AsQueryable();
        }

        public IQueryable<TEntity> GetRemoved()
        {
            return _list.AsQueryable().Where(t => t.Removed);
        }

        public TEntity GetById(int id)
        {
            var entity = _list.FirstOrDefault(t => t.Id == id);
            if (entity == null)
            {
                throw new Exception("Register not found!");
            }
            return entity;
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return Task.FromResult(GetById(id));
        }

        public Task AddAsync(TEntity entity)
        {
            if (_list.Any(t => t.Id == entity.Id))
            {
                throw new Exception("Register already exists!");
            }
            _list.Add(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TEntity entity)
        {
            var index = _list.FindIndex(t => t.Id == entity.Id);
            if (index == -1)
            {
                throw new Exception("Register not found!");
            }
            _list[index] = entity;
            return Task.CompletedTask;
        }

        public async Task SaveAsync(TEntity entity)
        {
            var exists = _list.Any(t => t.Id == entity.Id);
            if (exists)
            {
                await UpdateAsync(entity);
            }
            else
            {
                await AddAsync(entity);
            }
        }

        public Task DeleteAsync(int id)
        {
            var index = _list.FindIndex(t => t.Id == id);
            if (index == -1)
            {
                throw new Exception("Register not found!");
            }
            _list.RemoveAt(index);
            return Task.CompletedTask;
        }
    }
}
