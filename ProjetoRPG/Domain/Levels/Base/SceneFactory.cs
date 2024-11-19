using ProjetoRPG.Enums;
using ProjetoRPG.Levels.DTOs;

namespace ProjetoRPG.Levels.Base;

public class SceneFactory
{
    public static Scene CreateScene(EnumSceneType sceneType, NewSceneDto dto)
    {
        return sceneType switch
        {
            EnumSceneType.Story => new Story(),
            EnumSceneType.Zone => new CombatZone(),
            _ => throw new ArgumentException("Invalid scene type.")
        };
    }
}