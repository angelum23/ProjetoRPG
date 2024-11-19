using ProjetoRPG.Enums;
using ProjetoRPG.Levels;
using ProjetoRPG.Levels.Base;
using ProjetoRPG.Repository.Base;
using ProjetoRPG.Service.Base;
using ProjetoRPG.Service.Factory;

namespace ProjetoRPG.Service;

public class SceneService
{
    private readonly IServiceProvider _serviceProvider;
    public SceneService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    private ISceneService GetService(EnumSceneType sceneType)
    {
        var sceneServiceFactory = new SceneServiceFactory(_serviceProvider);
        return sceneServiceFactory.CreateSceneService(sceneType);
    }
    
    public void Save(IScene scene)
    {
        GetService(scene.SceneType).Save(scene);
    }
    
    public Task<IScene> GetAllAsync()
    {
        throw new NotImplementedException("Not implemented yet.");
    }

    public virtual IQueryable<IScene> Get()
    {
        throw new NotImplementedException("Not implemented yet.");
    }

    public Task<IScene> GetByIdAsync(int id)
    {
        throw new NotImplementedException("Not implemented yet.");
    }
}