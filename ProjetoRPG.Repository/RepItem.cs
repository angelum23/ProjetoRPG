using ProjetoRPG.Domain.Items;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository;

public class RepItem : RepBaseDbSet<Item>
{
    public RepItem(ApplicationDbContext context) : base(context)
    {
    }
}