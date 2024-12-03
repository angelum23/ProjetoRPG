using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Enums;
using ProjetoRPG.Game;

namespace ProjetoRPG.Levels.Base;

public interface ISceneService
{
    Task Act(IScene scene, Character playerCharacter);
    Task SaveAsync(IScene entity);
    Task<IScene> GetByIdAsync(int id);
}