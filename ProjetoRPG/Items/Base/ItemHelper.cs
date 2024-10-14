using ProjetoRPG.Base.Enums;

namespace ProjetoRPG.Items.Base;

public static class ItemHelper
{
    private static readonly Dictionary<EnumRarity, int> DropChance = new()
    {
        { EnumRarity.Common, 60 },
        { EnumRarity.Rare, 25 },
        { EnumRarity.Epic, 10 },
        { EnumRarity.Legendary, 5 }
    };
    
    public static Item? DropItemBasedOnChance(List<Item> items)
    {
        if (!items.Any()) return null;

        var totalDropChance = items.Sum(item => DropChance[item.Rarity]);
        var randomValue = Random.Shared.Next(totalDropChance);
        
        var accumulatedDropChance = 0;
        foreach (var item in items)
        {
            accumulatedDropChance += DropChance[item.Rarity];
            if (randomValue < accumulatedDropChance)
            {
                return item;
            }
        }

        return null;
    } 
}