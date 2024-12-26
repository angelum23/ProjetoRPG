using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.Base;
using ProjetoRPG.Domain.Levels;

namespace ProjetoRPG.Domain.Game;

public class Player : BaseEntity
{
    public int IdInventory { get; set; }
    public int IdCharacter { get; set; }
    public int IdCurrentLevel { get; set; }
    
    public Inventory Inventory { get; set; }
    public Character Character { get; set; }
    public Level CurrentLevel { get; set; }
}