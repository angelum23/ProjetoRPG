using Microsoft.EntityFrameworkCore;
using ProjetoRPG.Domain.Base;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;
using ProjetoRPG.Service.Factory;
using ProjetoRPG.Domain.Enums;
using ProjetoRPG.Domain.Levels;
using ProjetoRPG.Domain.Levels.Base;

namespace ProjetoRPG.Service;

public class ServLevel(RepLevel rep, 
                       RepCharacter repCharacter, 
                       IServiceProvider serviceProvider, 
                       RepItem repItem) : BaseServiceSubject<Level>(rep), IObserver
{
    private IServiceProvider _serviceProvider = serviceProvider;

    public async Task StartNextScene(int levelId)
    {
        var level = await GetByIdAsync(levelId);
        var sceneServiceFactory = new SceneServiceFactory(_serviceProvider);
        var service = sceneServiceFactory.CreateSceneService(level.ActualSceneType);

        var actualScene = await service.GetByIdAsync(level.IdActualScene);
        if (actualScene.IdNextScene != null)
        {
            level.IdActualScene = actualScene.IdNextScene.Value;
            await SaveAsync(level);
        }
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
        
        await SaveAsync(level);
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
            previousScene = await AddLevelScene(dto, previousScene, sceneServiceFactory, level);
        }
        
        level.IdFirstScene = previousScene.GetId();
        level.IdActualScene = level.IdFirstScene;
        
        await SaveAsync(level);
    }

    private async Task<IScene> AddLevelScene(NewSceneDto dto, IScene previousScene, SceneServiceFactory sceneServiceFactory, Level level)
    {
        var service = sceneServiceFactory.CreateSceneService(dto.Scene.SceneType);
        if (previousScene.Persisted())
        {
            dto.Scene.IdNextScene = previousScene.GetId();
            dto.Scene.NextScene = previousScene;
        }

        switch (dto.Scene.SceneType)
        {
            case EnumSceneType.Story:
                await service.SaveAsync(dto.Scene);
                break;
            case EnumSceneType.CombatZone:
                await AddCombatZone(dto, service, level);
                break;
            default:
                throw new NotImplementedException();
        }
        
        return dto.Scene;
    }

    private async Task AddCombatZone(NewSceneDto dto, ISceneService service, Level level)
    {
        if (dto.Scene.SceneType != EnumSceneType.CombatZone)
            throw new ArgumentException("The scene must be a combat zone to have an enemy.");
        
        if(dto.CombatZoneDto?.Enemy == null)
            throw new ArgumentException("The combat zone must have an enemy.");
        
        var combatZone = (CombatZone)dto.Scene;
        
        await SaveAsync(level);
        
        await repCharacter.SaveAsync(dto.CombatZoneDto.Enemy);
        combatZone.IdEnemy = dto.CombatZoneDto.Enemy.Id;
        
        if (dto.CombatZoneDto.Loot?.Item != null)
        {
            await repItem.SaveAsync(dto.CombatZoneDto.Loot.Item);
            combatZone.LootId = dto.CombatZoneDto.Loot.Item.Id;
        }
            

        await service.SaveAsync(combatZone);
    }
    
    public async Task ResetLevel(int idLevel)
    {
        var level = await GetByIdAsync(idLevel);
        level.IdActualScene = level.IdFirstScene;
        await SaveAsync(level);
    }

    #region IObserver
    public async Task Update(EnumObserverTrigger trigger, int? id = null)
    {
        switch (trigger)
        {
            case EnumObserverTrigger.OnSceneEnd:
                await HandleStartNextScene(id);
                break;
            default: 
                throw new NotImplementedException();
        }
    }

    private async Task HandleStartNextScene(int? id)
    {
        if (!id.HasValue)
        {
            return;
        }
        
        var level = await Get().Where(l => l.IdActualScene == id).FirstOrDefaultAsync();
        if (level == null)
        {
            return;
        }
        
        await StartNextScene(level.Id);
    }

    #endregion
}