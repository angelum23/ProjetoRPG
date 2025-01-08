using ProjetoRPG.Domain.Game;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Players;

public class RepPlayer : BaseRepDbSet<Player>
{
    public RepPlayer(ApplicationDbContext context) : base(context)
    {
    }
}