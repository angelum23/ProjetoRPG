﻿using ProjetoRPG.Classes.Base;
using ProjetoRPG.Enums;
using ProjetoRPG.Levels;
using ProjetoRPG.Levels.Base;
using ProjetoRPG.Repository;
using ProjetoRPG.Repository.Base;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class ServStory : BaseService<Story>, ISceneService
{
    private readonly RepStory? _repStory;
    public ServStory(IServiceProvider serviceProvider) : base(serviceProvider.GetRequiredService<RepStory>())
    {
        _repStory = serviceProvider.GetRequiredService<RepStory>();
    }
    
    public async Task Act(IScene scene, Character playerCharacter)
    {
        if (scene.SceneType != EnumSceneType.Story)
        {
            throw new ArgumentException("The scene must be a story.");
        }
        
        var story = (Story)scene;
        var storyText = story.Description;
        storyText = storyText.Replace("{characterName}", playerCharacter.Name);
        
        Console.WriteLine(storyText);
        
    }
    
    public async Task SaveAsync(IScene entity)
    {
        await base.SaveAsync((Story)entity);
    }
    
    public new async Task<IScene> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }
}