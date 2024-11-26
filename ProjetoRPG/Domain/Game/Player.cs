using ProjetoRPG.Base;
using ProjetoRPG.Classes.Base;
using ProjetoRPG.Levels;

namespace ProjetoRPG.Game;

public class Player : BaseEntity
{
    public int IdInventory { get; set; }
    public int IdCharacter { get; set; }
    public int IdCurrentLevel { get; set; }
    
    public Inventory Inventory { get; set; }
    public Character Character { get; set; }
    public Level CurrentLevel { get; set; }
}