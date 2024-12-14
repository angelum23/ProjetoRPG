using ProjetoRPG.Domain.Base;
using ProjetoRPG.Domain.Enums;

namespace ProjetoRPG.Domain.Levels;

public class Story : BaseEntitySubject, IScene
{
    public string Name { get; set; }
    public string Description { get; set; }
    public EnumSceneType SceneType { get; set; }
    public int? IdNextScene { get; set; }
    
    public IScene? NextScene { get; set; }

    public int GetId()
    {
        return Id;
    }

    public bool Persisted() => Id > 0;
    public Task Update(EnumObserverTrigger trigger, int? id = null)
    {
        throw new NotImplementedException();
    }
}