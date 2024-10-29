namespace ProjetoRPG.Service.Base;

public interface IBaseService<T>
{
    Task<T> Save(T entity);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<bool> HardDeleteAsync(int id);
    Task<bool> RemoveAsync(int id);
}