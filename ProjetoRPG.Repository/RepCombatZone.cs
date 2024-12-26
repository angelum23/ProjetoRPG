using ProjetoRPG.Domain.Levels;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository;

public class RepCombatZone : RepBaseDbSet<CombatZone>
{
    public RepCombatZone(ApplicationDbContext context) : base(context)
    {
    }
}
