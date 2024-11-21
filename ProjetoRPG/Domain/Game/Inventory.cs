using ProjetoRPG.Items.Base;

namespace ProjetoRPG.Game;

public class Inventory
{
    public List<Item> Items { get; }
    public int Capacity { get; set; } = 60;
    public double Gold { get; set; }
    
    #region Methods
    public void AddItem(Item item)
    {
        if (Items.Count >= Capacity)
        {
            return;
        }
        
        Items.Add(item);
    }

    public void DropItem(Item item)
    {
        if (Items.Count <= 0)
        {
            return;
        }
        
        Items.Remove(item);
    }
    #endregion
}