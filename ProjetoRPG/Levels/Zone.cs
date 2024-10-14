using ProjetoRPG.Base;
using ProjetoRPG.Items.Base;

namespace ProjetoRPG.Levels;

public class Zone
{
    public string Name { get; set; } = "";
    public int DropPerc { get; set; } = 100;
    public List<Item> Loots { get; } = [];
    public List<ZoneEnemy> Enemies { get; } = [];
    public List<Zone> Paths { get; } = [];

    #region Methods
    
    #region Loots
    
    public void AddLoots(Item loot) {
        Loots.Add(loot);
    }
    
    public void RemoveLoots(Item loot) {
        Loots.Remove(loot);
    }
    
    #endregion
    
    #region Enemies
    
    public void AddEnemy(ZoneEnemy enemy) {
        Enemies.Add(enemy);
    }
    
    public void RemoveEnemy(ZoneEnemy enemy) {
        Enemies.Remove(enemy);
    }
    
    #endregion
    
    #region Paths
    
    public void AddPaths(Zone path) {
        Paths.Add(path);
    }
    
    public void RemovePaths(Zone path) {
        Paths.Remove(path);
    }
    
    #endregion
    
    public void OnClearZone(Player.Player player)
    {
        var zoneName = Name.Length > 0 ? (Name + " ") : "";
        Console.WriteLine($"Zone {zoneName}was cleared");
        
        if (Random.Shared.Next(0, 100) <= DropPerc)
        {
            return;
        }
        
        var drop = ItemHelper.DropItemBasedOnChance(Loots);
        if (drop == null)
        {
            return;
        }
        
        Console.WriteLine($"Dropped {drop.Name}");
        player.Inventory.AddItem(drop);
    } 
    #endregion
}