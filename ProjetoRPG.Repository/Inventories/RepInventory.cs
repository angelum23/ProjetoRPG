using ProjetoRPG.Domain.Game;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Inventories;

public class RepInventory : RepBaseDbSet<Inventory>
{
    public RepInventory(ApplicationDbContext context) : base(context)
    {
    }
}