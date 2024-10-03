using ProjetoRPG.Base;
using ProjetoRPG.Base.Enums;

namespace ProjetoRPG.Classes;

public class Necromancer : Character
{
    public Necromancer(string name, float damage, float accuracy, float range, float totalHealth, float currentHealth, float regeneration, float armor, float magicResist, float agility, float magicDamage, float currentMana, float totalMana, float manaRegeneration, float level, float xpPerc, EnumMobType mobType)
        : base(name, damage, accuracy, range, totalHealth, currentHealth, regeneration, armor, magicResist, agility, magicDamage, currentMana, totalMana, manaRegeneration, level, xpPerc, mobType)
    {}

    public Necromancer NewNecromancer(string name, EnumMobType mobType) => BaseClassesAtributes.Necromancer(name, mobType);
}