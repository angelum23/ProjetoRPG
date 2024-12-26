using ProjetoRPG.Domain.Game;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository;

public class RepPlayer : RepBaseDbSet<Player>
{
    public RepPlayer(ApplicationDbContext context) : base(context)
    {
    }
}