using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.Base;

namespace ProjetoRPG.Domain.Levels.Base;

public interface ISceneService : IObserver
{
    Task Act(IScene scene, Character playerCharacter);
    Task SaveAsync(IScene entity);
    Task<IScene> GetByIdAsync(int id);
}