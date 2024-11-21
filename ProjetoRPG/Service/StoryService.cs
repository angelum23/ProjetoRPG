using ProjetoRPG.Levels;
using ProjetoRPG.Levels.Base;
using ProjetoRPG.Repository;
using ProjetoRPG.Repository.Base;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class StoryService : BaseService<Story>, ISceneService
{
    private readonly RepStory? _repStory;
    public StoryService(IServiceProvider serviceProvider) : base(serviceProvider.GetService<RepStory>())
    {
        _repStory = serviceProvider.GetService<RepStory>();
    }

    public new async Task<Scene?> GetByIdAsync(int storyId)
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

    public void StartNextScene()
    {
        throw new NotImplementedException();
    }
}