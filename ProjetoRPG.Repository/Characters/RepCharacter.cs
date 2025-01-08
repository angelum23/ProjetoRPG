using ProjetoRPG.Domain.Classes.Base;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Characters;

public class RepCharacter : BaseRepDbSet<Character>
{
    public RepCharacter(ApplicationDbContext context) : base(context)
    {
    }
}