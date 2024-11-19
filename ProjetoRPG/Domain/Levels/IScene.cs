using ProjetoRPG.Enums;

namespace ProjetoRPG.Levels;

public interface IScene
{
    public string Name { get; set; }
    public string Description { get; set; }
    public EnumSceneType SceneType { get; set; }
    public Scene NextScene { get; set; }
}