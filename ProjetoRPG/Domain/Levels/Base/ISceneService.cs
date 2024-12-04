using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Enums;
using ProjetoRPG.Game;
using ProjetoRPG.Infra.ObserverPattern;

namespace ProjetoRPG.Levels.Base;

public interface ISceneService : IObserver
{
    Task Act(IScene scene, Character playerCharacter);
    Task SaveAsync(IScene entity);
    Task<IScene> GetByIdAsync(int id);
}