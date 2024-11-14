using ProjetoRPG.Base;
using ProjetoRPG.Enums;

namespace ProjetoRPG.Items.Base;

public class Item : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float BuyPrice { get; set; }
    private const int PercTaxSelling = 20;
    public float SellPrice () => (BuyPrice * (100 - PercTaxSelling) / 100);
    public EnumRarity Rarity { get; set; }
    public EnumItemType ItemType { get; set; }
    
    //Status
    public float BonusTotalHealth { get; set; }
    public float BonusRegeneration { get; set; }
    public float BonusArmor { get; set; }
    public float BonusMagicResist { get; set; }
    public float BonusAgility { get; set; }
    public float BonusTotalMana { get; set; }
    public float BonusManaRegeneration { get; set; }
    public float BonusDamage { get; set; }
    public float BonusAccuracy { get; set; }
    public float BonusRange { get; set; }
    public float BonusMagicDamage { get; set; }
}