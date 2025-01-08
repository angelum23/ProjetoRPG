using ProjetoRPG.Domain.Game;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.InventoryItems;

public class RepInventoryItem : BaseRepDbSet<InventoryItem>
{
    public RepInventoryItem(ApplicationDbContext context) : base(context)
    {
    }
}