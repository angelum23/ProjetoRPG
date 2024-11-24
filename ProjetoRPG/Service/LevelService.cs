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

public class LevelService(RepLevel rep, PlayerService playerService, RepStory repStory, RepCombatZone repCombatZone, IServiceProvider serviceProvider) : BaseService<Level>(rep)
{
    private IServiceProvider _serviceProvider = serviceProvider;

    public async void StartNextScene(Level level)
    {
        level.ActualScene = level.ActualScene?.NextScene;
        
        if(level.ActualScene != null)
        {
            return;
        }
        
        var player = await playerService.GetPlayer();
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

        var scenes = dto.Scenes;
        
        await rep.AddAsync(level);
        return level;
    }
    
    public async Task AddScenes(Level level, List<IScene> scenes)
    {
        if (scenes == null || scenes.Count == 0)
            throw new ArgumentException("The scenes list cannot be null or empty.");

        level.ActualScene = scenes[0];
        var sceneServiceFactory = new SceneServiceFactory(_serviceProvider);

        for (var i = 0; i < scenes.Count; i++)
        {
            var currentScene = scenes[i];
            currentScene.NextScene = (i + 1 < scenes.Count) ? scenes[i + 1] : null;

            var sceneService = sceneServiceFactory.CreateSceneService(currentScene.SceneType);
            await sceneService.Save(currentScene);
        }
    }
}