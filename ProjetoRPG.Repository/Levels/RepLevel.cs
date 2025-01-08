using ProjetoRPG.Domain.Levels;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Levels;

public class RepLevel : BaseRepDbSet<Level>
{
    public RepLevel(ApplicationDbContext context) : base(context)
    {
    }
}