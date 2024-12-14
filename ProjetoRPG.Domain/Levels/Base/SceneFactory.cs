using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Domain.Enums;

namespace ProjetoRPG.Domain.Levels.Base;

public class SceneFactory
{
    public static IScene CreateScene(EnumSceneType sceneType, NewSceneDto dto)
    {
        return sceneType switch
        {
            EnumSceneType.Story => new Story(),
            EnumSceneType.CombatZone => new CombatZone(),
            _ => throw new ArgumentException("Invalid scene type.")
        };
    }
}