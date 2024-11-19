using ProjetoRPG.Levels;
using ProjetoRPG.Levels.Base;
using ProjetoRPG.Repository;
using ProjetoRPG.Repository.Base;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class StoryService : BaseService<Story>, ISceneService
{
    public StoryService(IServiceProvider serviceProvider) : base(serviceProvider.GetService<RepStory>())
    {
    }

    public void Act()
    {
        throw new NotImplementedException();
    }

    public void StartScene()
    {
        throw new NotImplementedException();
    }

    public void EndScene()
    {
        throw new NotImplementedException();
    }

    public void StartNextScene()
    {
        throw new NotImplementedException();
    }
}