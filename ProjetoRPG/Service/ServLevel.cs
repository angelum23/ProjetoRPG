using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Levels;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;
using ProjetoRPG.Service.Factory;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Enums;
using ProjetoRPG.Levels.Base;

namespace ProjetoRPG.Service;

public class ServLevel(RepLevel rep, RepCharacter repCharacter, IServiceProvider serviceProvider, RepItem repItem) : BaseService<Level>(rep)
{
    private IServiceProvider _serviceProvider = serviceProvider;

    public async void StartNextScene(Level level)
    {
        var sceneServiceFactory = new SceneServiceFactory(_serviceProvider);
        var service = sceneServiceFactory.CreateSceneService(level.ActualSceneType);

        var actualScene = await service.GetById(level.IdActualScene);
        if (actualScene.IdNextScene != null)
        {
            level.IdActualScene = actualScene.IdNextScene.Value;
            await rep.UpdateAsync(level);
            return;
        }
        
        // var player = await servPlayer.GetPlayer(); // Notify player with observer pattern
        // player.Inventory.Gold += level.GoldReward;
        // Console.WriteLine($"Level {level.Name} completed. You received {level.GoldReward} gold.");
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
    
    private async Task AddScenes(Level level, List<NewSceneDto> dtoList)
    {
        if (dtoList == null || dtoList.Count == 0)
            throw new ArgumentException("The scenes list cannot be null or empty.");

        var sceneServiceFactory = new SceneServiceFactory(_serviceProvider);
        
        IScene previousScene = new Story();

        var reverseDtoList = dtoList.AsEnumerable().Reverse();
        foreach (var dto in reverseDtoList)
        {
            previousScene = await AddLevelScene(dto, previousScene, sceneServiceFactory);
        }
        
        level.IdFirstScene = previousScene.GetId();
        level.IdActualScene = level.IdFirstScene;
        
        await rep.SaveAsync(level);
    }

    private async Task<IScene> AddLevelScene(NewSceneDto dto, IScene previousScene, SceneServiceFactory sceneServiceFactory)
    {
        var service = sceneServiceFactory.CreateSceneService(dto.Scene.SceneType);
        if (previousScene.Persisted())
        {
            dto.Scene.IdNextScene = previousScene.GetId();
            dto.Scene.NextScene = previousScene;
        }

        if (dto.CombatZoneDto?.Enemy?.Id != null)
        {
            await AddCombatZone(dto, service);
            return dto.Scene;
        }
            
        await service.Save(dto.Scene);
        return dto.Scene;
    }

    private async Task AddCombatZone(NewSceneDto dto, ISceneService service)
    {
        if (dto.Scene.SceneType != EnumSceneType.CombatZone)
            throw new ArgumentException("The scene must be a combat zone to have an enemy.");
        
        if(dto.CombatZoneDto?.Enemy == null)
            throw new ArgumentException("The combat zone must have an enemy.");
        
        var combatZone = (CombatZone)dto.Scene;
        
        await repCharacter.SaveAsync(dto.CombatZoneDto.Enemy);
        combatZone.IdEnemy = dto.CombatZoneDto.Enemy.Id;
        
        if (dto.CombatZoneDto.Loot?.Item != null)
        {
            await repItem.SaveAsync(dto.CombatZoneDto.Loot.Item);
            combatZone.LootId = dto.CombatZoneDto.Loot.Item.Id;
        }
            

        await service.Save(combatZone);
    }
}