using ProjetoRPG.Enums;

namespace ProjetoRPG.Levels;

public class Story : Scene
{
    public Story(int idScene, 
                 string name, 
                 string description, 
                 EnumSceneType sceneType, 
                 Scene nextScene) : base(idScene, name, description, sceneType, nextScene)
    {
    }

    public override void Act()
    {
        //Todo: Implementar a lógica de exibir a próxima parte da história
        Console.WriteLine("Story Act");
    }

    public override void StartScene()
    {
        //Todo: Implementar a lógica de exibir o título e começo da história
    }

    public override void EndScene()
    {
        //Todo: Implementar a lógica de exibir o final da história
    }
}