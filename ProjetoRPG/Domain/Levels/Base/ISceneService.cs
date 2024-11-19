using ProjetoRPG.Enums;

namespace ProjetoRPG.Levels.Base;

public interface ISceneService
{
    Task<List<IScene>> GetAllAsync();
    void Get();
    Task<IScene> GetByIdAsync(int id);
    Task<IScene> Save(IScene entity);
    Task HardDeleteAsync(int id);
    Task RemoveAsync(int id);
    public void Act();
    public void StartScene();
    
    public void EndScene();

    public void StartNextScene();
}