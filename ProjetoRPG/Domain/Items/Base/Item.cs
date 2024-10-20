using ProjetoRPG.Enums;

namespace ProjetoRPG.Items.Base;

public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float BuyPrice { get; set; }
    private const int PercTaxSelling = 20;
    public float SellPrice () => (BuyPrice * (100 - PercTaxSelling) / 100);
    public EnumRarity Rarity { get; set; }
}