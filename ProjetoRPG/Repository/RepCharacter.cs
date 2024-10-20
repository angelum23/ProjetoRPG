using ProjetoRPG.Classes.Base;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository;

public class RepCharacter : RepBase<Character>
{
    public RepCharacter(ApplicationDbContext context) : base(context) { }
}