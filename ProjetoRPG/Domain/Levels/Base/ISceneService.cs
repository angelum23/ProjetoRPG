using ProjetoRPG.Enums;

namespace ProjetoRPG.Levels.Base;

public interface ISceneService
{
    public void Act();

    public void StartNextScene();
    Task<Scene?> GetByIdAsync(int sceneId);
}