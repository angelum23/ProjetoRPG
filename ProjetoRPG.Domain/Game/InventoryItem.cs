using ProjetoRPG.Domain.Base;
using ProjetoRPG.Domain.Items;

namespace ProjetoRPG.Domain.Game;

public class InventoryItem : BaseEntity
{
    public int IdItem { get; set; }
    public int IdInventory { get; set; }
    
    public Item Item { get; set; }
    public Inventory Inventory { get; set; }
}