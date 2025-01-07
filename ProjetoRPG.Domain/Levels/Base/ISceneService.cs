using ProjetoRPG.Domain.Base;
using ProjetoRPG.Domain.Classes.Base;

namespace ProjetoRPG.Domain.Levels.Base;

public interface ISceneService : IObserver
{
    Task Act(IScene scene, Character playerCharacter);
    Task SaveAsync(IScene entity);
    Task<IScene> GetByIdAsync(int id);
}