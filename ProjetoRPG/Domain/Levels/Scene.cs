using ProjetoRPG.Base;
using ProjetoRPG.Enums;

namespace ProjetoRPG.Levels;

public abstract class Scene : BaseEntity
{
    public int IdScene { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public EnumSceneType SceneType { get; set; }
    public Scene NextScene { get; set; }

    public abstract void Act();
    public abstract void StartScene();
    
    public abstract void EndScene();

    public void StartNextScene()
    {
        EndScene();
        NextScene.StartScene();
    }
}