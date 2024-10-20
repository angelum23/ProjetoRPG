using Microsoft.AspNetCore.Mvc;


namespace ProjetoRPG.Controller;

public abstract class BaseController<T> : ControllerBase
{
    
    public IActionResult Save(T entidade)
    {
        throw new NotImplementedException();
    }
}