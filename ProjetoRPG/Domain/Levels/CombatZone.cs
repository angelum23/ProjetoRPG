using ProjetoRPG.Actions;
using ProjetoRPG.Classes.Base;
using ProjetoRPG.Enums;
using ProjetoRPG.Game;
using ProjetoRPG.Items.Base;

namespace ProjetoRPG.Levels;

public class CombatZone : Scene
{
    public int IdCharacter { get; set; }
    public Player Player { get; set; }
    public Character Enemy { get; set; }
    public int DropPerc { get; set; } = 100;
    public List<Item> Loots { get; set; }
}