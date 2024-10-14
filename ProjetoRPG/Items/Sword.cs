using ProjetoRPG.Items.Base;

namespace ProjetoRPG.Items;

public class Sword : Item
{
    public float BonusDamage { get; set; }
    public float BonusAccuracy { get; set; }
    public float BonusRange { get; set; }
    public float BonusAgility { get; set; }
}