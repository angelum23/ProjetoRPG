using ProjetoRPG.Base;
using ProjetoRPG.Base.Enums;

namespace ProjetoRPG.Classes;

public class Ninja : Character<Ninja>
{
    public Ninja(string name, float damage, float accuracy, float range, float totalHealth, float currentHealth, float regeneration, float armor, float magicResist, float agility, float magicDamage, float mana, float manaRegeneration, float level, float xpPerc, EnumMobType mobType) 
        : base(name, damage, accuracy, range, totalHealth, currentHealth, regeneration, armor, magicResist, agility, magicDamage, mana, manaRegeneration, level, xpPerc, mobType)
    {
    }
    
    public Ninja NewNinja(string name, EnumMobType mobType) => (Ninja)BaseClassesAtributes.Ninja(name, mobType);
}