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
    public async void AddScene(AddSceneDto dto)
    {
        var factory = new SceneServiceFactory(serviceProvider);
        var sceneService = factory.CreateSceneService(dto.SceneType);
        
        var scene = await sceneService.GetByIdAsync(dto.SceneId);
        if (scene == null)
        {
            throw new Exception("Scene not found.");
        }
        
        var level = await rep.GetByIdAsync(dto.LevelId);
        if (level.ActualScene == null)
        {
            level.ActualScene = scene;
            return;
        }
        
        scene.GetLastScene().NextScene = scene;
    }
    
    public async void StartNextScene(Level level)
    {
        level.ActualScene = level.ActualScene?.NextScene;
        
        if(level.ActualScene != null)
        {
            return;
        }
        
        var player = await playerService.GetPlayer();
        player.Inventory.Gold += level.GoldReward;
        Console.WriteLine($"Level {level.LevelName} completed. You received {level.GoldReward} gold.");
    }}