using ProjetoRPG.Base;
using ProjetoRPG.Base.Enums;

namespace ProjetoRPG.Classes;

public class Necromancer : Character<Necromancer>
{
    public Necromancer(string name, float damage, float accuracy, float range, float totalHealth, float currentHealth, float regeneration, float armor, float magicResist, float agility, float magicDamage, float mana, float manaRegeneration, float level, float xpPerc, EnumMobType mobType) 
        : base(name, damage, accuracy, range, totalHealth, currentHealth, regeneration, armor, magicResist, agility, magicDamage, mana, manaRegeneration, level, xpPerc, mobType)
    {
    }
    
    public Necromancer NewNecromancer(string name, EnumMobType mobType) => (Necromancer)BaseClassesAtributes.Necromancer(name, mobType);
}