using ProjetoRPG.Levels;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Controller;

public class LevelController : BaseController<Level>
{
    public LevelController(IBaseService<Level> service) : base(service)
    {
    }
}