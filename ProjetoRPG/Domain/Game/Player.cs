using ProjetoRPG.Base;
using ProjetoRPG.Classes.Base;

namespace ProjetoRPG.Game;

public class Player : BaseEntity
{
    public int IdInventory { get; set; }
    public int IdCharacter { get; set; }
    
    public Inventory Inventory { get; set; }
    public Character Character { get; set; }
}