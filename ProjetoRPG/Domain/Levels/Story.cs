using ProjetoRPG.Base;
using ProjetoRPG.Enums;

namespace ProjetoRPG.Levels;

public class Story : BaseEntity, IScene
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
}