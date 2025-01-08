using ProjetoRPG.Domain.Items;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Items;

public class RepItem : BaseRepDbSet<Item>
{
    public RepItem(ApplicationDbContext context) : base(context)
    {
    }
}