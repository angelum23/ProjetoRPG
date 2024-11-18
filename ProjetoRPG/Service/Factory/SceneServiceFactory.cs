using ProjetoRPG.Enums;

namespace ProjetoRPG.Service.Factory;

public class SceneServiceFactory
{
    public static SceneService CreateSceneService(EnumSceneType sceneType)
    {
        return sceneType switch
        {
            EnumSceneType.Story => new StoryService(),
            EnumSceneType.Zone => new CombatZoneService(),
            _ => throw new ArgumentException("Invalid scene type.")
        };
    }
}