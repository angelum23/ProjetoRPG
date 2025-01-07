using ProjetoRPG.Domain.Game;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.InventoryItems;

public class RepInventoryItem : RepBaseDbSet<InventoryItem>
{
    public RepInventoryItem(ApplicationDbContext context) : base(context)
    {
    }
}