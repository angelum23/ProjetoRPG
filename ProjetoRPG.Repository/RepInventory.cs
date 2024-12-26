using ProjetoRPG.Domain.Game;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository;

public class RepInventory : RepBaseDbSet<Inventory>
{
    public RepInventory(ApplicationDbContext context) : base(context)
    {
    }
}