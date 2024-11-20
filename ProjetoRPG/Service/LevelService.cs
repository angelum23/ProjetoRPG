using ProjetoRPG.Enums;
using ProjetoRPG.Levels;
using ProjetoRPG.Levels.DTOs;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class LevelService(RepLevel rep, RepStory repStory, RepCombatZone repCombatZone) : BaseService<Level>(rep)
{
    public async void AddScene(AddSceneDto dto)
    {
        var scene = dto.SceneType switch
        {
            EnumSceneType.Story => await repStory.GetByIdAsync(dto.SceneId),
            EnumSceneType.Zone => await repCombatZone.GetByIdAsync(dto.SceneId),
            _ => throw new ArgumentException("Invalid scene type.")
        };
        
        if (scene == null)
        {
            throw new Exception("Scene not found.");
        }
        
        var level = await rep.GetByIdAsync(dto.LevelId);
        if (level.FirstScene == null)
        {
            level.FirstScene = scene;
            return;
        }
        
        scene.GetLastScene().NextScene = scene;
    }
}