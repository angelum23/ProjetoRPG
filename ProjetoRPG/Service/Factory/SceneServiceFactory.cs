using ProjetoRPG.Enums;
using ProjetoRPG.Levels.Base;

namespace ProjetoRPG.Service.Factory;

public class SceneServiceFactory
{
    private readonly IServiceProvider _serviceProvider;
    
    public SceneServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public ISceneService CreateSceneService(EnumSceneType sceneType)
    {
        return sceneType switch
        {
            EnumSceneType.Story => new StoryService(_serviceProvider),
            EnumSceneType.Zone => new CombatZoneService(_serviceProvider),
            _ => throw new ArgumentException("Invalid scene type.")
        };
    }
}