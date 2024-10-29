using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Service.Base;

public abstract class BaseService<T> : IBaseService<T> where T : class
{
    #region Ctor
    
    //todo Criar construtor daquele jeito maroto com abstract
    
    #endregion
    
    public Task<List<T>> GetAllAsync()
    {
        
    }

    public Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
    
    public Task<T> Save(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HardDeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(int id)
    {
        throw new NotImplementedException();
    }
}