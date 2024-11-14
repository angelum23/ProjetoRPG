using ProjetoRPG.Base;
using ProjetoRPG.Enums;

namespace ProjetoRPG.Levels;

public abstract class Scene : BaseEntity
{
    protected Scene(int idScene, string name, string description, EnumSceneType sceneType, Scene nextScene)
    {
        IdScene = idScene;
        Name = name;
        Description = description;
        SceneType = sceneType;
        NextScene = nextScene;
    }

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