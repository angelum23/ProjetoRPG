using Microsoft.Extensions.DependencyInjection;
using ProjetoRPG.Domain.Enums;
using ProjetoRPG.Domain.Levels.Base;
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
            EnumSceneType.Story => (ISceneService)_serviceProvider.GetRequiredService(typeof(ServStory)),
            EnumSceneType.CombatZone => (ISceneService)_serviceProvider.GetRequiredService(typeof(ServCombatZone)),
            _ => throw new ArgumentException("Invalid scene type.")
        };
    }
}