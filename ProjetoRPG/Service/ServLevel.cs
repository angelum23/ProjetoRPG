using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Enums;
using ProjetoRPG.Game;
using ProjetoRPG.Levels;
using ProjetoRPG.Levels.Base;
using ProjetoRPG.Levels.DTOs;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;
using ProjetoRPG.Service.Factory;

namespace ProjetoRPG.Service;

public class ServLevel(RepLevel rep, ServPlayer servPlayer, RepStory repStory, RepCombatZone repCombatZone, IServiceProvider serviceProvider) : BaseService<Level>(rep)
{
    private IServiceProvider _serviceProvider = serviceProvider;

    public async void StartNextScene(Level level)
    {
        level.ActualScene = level.ActualScene?.NextScene;
        
        if(level.ActualScene != null)
        {
            return;
        }
        
        var player = await servPlayer.GetPlayer();
        player.Inventory.Gold += level.GoldReward;
        Console.WriteLine($"Level {level.Name} completed. You received {level.GoldReward} gold.");
    }

    public async Task<Level> NewLevel(NewLevelDto dto)
    {
        if (!dto.Scenes.Any())
        {
            throw new Exception("Level must have at least one scene.");
        }
        
        var level = new Level
        {
            Name = dto.Name,
            GoldReward = dto.GoldReward
        };

        await AddScenes(level, dto.Scenes);
        
        await rep.AddAsync(level);
        return level;
    }
    
    public async Task AddScenes(Level level, List<IScene> scenes)
    {
        if (scenes == null || scenes.Count == 0)
            throw new ArgumentException("The scenes list cannot be null or empty.");

        var sceneServiceFactory = new SceneServiceFactory(_serviceProvider);
        
        IScene previousScene = new Story();

        var scenesInverse = scenes.AsEnumerable().Reverse();
        foreach (var scene in scenesInverse)
        {
            var service = sceneServiceFactory.CreateSceneService(scene.SceneType);
            if (previousScene.Persisted())
            {
                scene.IdNextScene = previousScene.GetId();
                scene.NextScene = previousScene;
            }
            
            await service.Save(scene);
            previousScene = scene;
        }
    }
}