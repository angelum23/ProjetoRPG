using ProjetoRPG.Base.Enums;

namespace ProjetoRPG.Levels;

public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public float Cost { get; set; }
    public EnumRarity Rarity { get; set; }
}