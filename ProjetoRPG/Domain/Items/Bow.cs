using ProjetoRPG.Items.Base;

namespace ProjetoRPG.Items;

public class Bow : Item
{
    public float BonusDamage { get; set; }
    public float BonusAccuracy { get; set; }
    public float BonusRange { get; set; }
    public float BonusRegeneration { get; set; }
    public float BonusAgility { get; set; }
}