using ProjetoRPG.Items.Base;

namespace ProjetoRPG.Items;

public class Staff : Item
{
    public float BonusAccuracy { get; set; }
    public float BonusRange { get; set; }
    public float BonusMagicResist { get; set; }
    public float BonusAgility { get; set; }
    public float BonusMagicDamage { get; set; }
    public float BonusTotalMana { get; set; }
    public float BonusManaRegeneration { get; set; }
}