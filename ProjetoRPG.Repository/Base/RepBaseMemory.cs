using ProjetoRPG.Domain.Base;

namespace ProjetoRPG.Repository.Base
{
    public class RepBaseMemory<TEntity> : IRepBase<TEntity> where TEntity : BaseEntity
    {
        private readonly List<TEntity> _list = new();

        public IQueryable<TEntity> Get()
        {
            return _list.AsQueryable().Where(e => !e.Removed);
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

            if (entity.Removed)
            {
                throw new Exception("Register was removed!");
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

            TrySetId(entity);
            
            _list.Add(entity);
            return Task.CompletedTask;
        }
        
        private void TrySetId(TEntity entity)
        {
            if (entity.Id != 0)
            {
                throw new Exception("Entity already has an Id!");
            }
            
            entity.Id = _list.Any() ? _list.Max(t => t.Id) + 1 : 1;
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
