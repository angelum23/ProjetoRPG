using ProjetoRPG.Base;
using ProjetoRPG.Items.Base;

namespace ProjetoRPG.Game;

public class InventoryItem : BaseEntity
{
    public int IdItem { get; set; }
    public int IdInventory { get; set; }
    
    public Item Item { get; set; }
    public Inventory Inventory { get; set; }
}