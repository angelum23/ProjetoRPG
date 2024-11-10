using ProjetoRPG.Items.Base;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Controller;

public class ItemController(IBaseService<Item> service) : BaseController<Item>(service)
{
    
};