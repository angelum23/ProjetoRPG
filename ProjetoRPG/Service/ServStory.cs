﻿using ProjetoRPG.Levels;
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

    public new async Task<IScene?> GetByIdAsync(int storyId)
    {
        if (_repStory == null)
        {
            throw new Exception("Story repository not found.");
        }
        
        return await _repStory!.GetByIdAsync(storyId);
    }
    
    public void Act()
    {
        throw new NotImplementedException();
    }
    
    public async Task Save(IScene entity)
    {
        await base.SaveAsync((Story)entity);
    }
    
    public async Task<IScene> GetById(int id)
    {
        return await base.GetByIdAsync(id);
    }
}