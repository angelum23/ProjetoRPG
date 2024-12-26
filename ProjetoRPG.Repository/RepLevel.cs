using ProjetoRPG.Domain.Levels;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository;

public class RepLevel : RepBaseDbSet<Level>
{
    public RepLevel(ApplicationDbContext context) : base(context)
    {
    }
}