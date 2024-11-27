using ProjetoRPG.Enums;

namespace ProjetoRPG.Levels.Base;

public interface ISceneService
{
    public void Act();
    Task Save(IScene entity);
    Task<IScene> GetById(int id);
}