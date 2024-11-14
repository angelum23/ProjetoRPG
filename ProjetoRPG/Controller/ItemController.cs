using Microsoft.AspNetCore.Mvc;
using ProjetoRPG.Items.Base;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Controller;

public class ItemController : BaseController<Item>
{
    public ItemController(IBaseService<Item> service) : base(service)
    {
    }
};