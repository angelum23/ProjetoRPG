using ProjetoRPG.Base;
using ProjetoRPG.Classes.Base;

namespace ProjetoRPG.Actions;

public class Combat : BaseEntity
{
    public int IdCharacter { get; set; }
    public Character Character { get; set; }
    public int IdEnemy { get; set; }
    public Character Enemy { get; set; }

    public void Atack()
    {
        Character.Attack(Enemy);
    }
}