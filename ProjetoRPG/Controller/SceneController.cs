using ProjetoRPG.Levels;
using ProjetoRPG.Levels.Base;
using ProjetoRPG.Service;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Controller;

public class SceneController : BaseController<Scene>
{
    public SceneController(SceneService service) : base(service)
    {
    }
}