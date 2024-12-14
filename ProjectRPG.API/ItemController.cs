using ProjetoRPG.Base;
using ProjetoRPG.Domain.Items;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG;

public class ItemController : BaseController<Item>
{
    public ItemController(IBaseService<Item> service) : base(service)
    {
    }
};