using ProjetoRPG.Domain.Game;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository;

public class RepInventoryItem : RepBaseDbSet<InventoryItem>
{
    public RepInventoryItem(ApplicationDbContext context) : base(context)
    {
    }
}