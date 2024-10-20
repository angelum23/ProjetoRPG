using ProjetoRPG.Items.Base;

namespace ProjetoRPG.Items;

public class Armor : Item
{
    public float BonusTotalHealth { get; set; }
    public float BonusRegeneration { get; set; }
    public float BonusArmor { get; set; }
    public float BonusMagicResist { get; set; }
    public float BonusAgility { get; set; }
    public float BonusTotalMana { get; set; }
    public float BonusManaRegeneration { get; set; }
}