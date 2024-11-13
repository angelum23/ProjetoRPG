using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Enums;

namespace ProjetoRPG.Classes;

public class Ninja : Character
{
    public Ninja(string name, 
                 float damage, 
                 float accuracy, 
                 float range, 
                 float totalHealth, 
                 float currentHealth, 
                 float regeneration, 
                 float armor, 
                 float magicResist, 
                 float agility, 
                 float magicDamage, 
                 float currentMana, 
                 float totalMana, 
                 float manaRegeneration, 
                 float level, 
                 float xpPerc, 
                 EnumMobType mobType)
        : base(name, 
               damage, 
               accuracy, 
               range, 
               totalHealth, 
               currentHealth, 
               regeneration, 
               armor, 
               magicResist, 
               agility, 
               magicDamage, 
               currentMana, 
               totalMana, 
               manaRegeneration, 
               level, 
               xpPerc, 
               mobType, 
               EnumClassType.Ninja)
    {}

    public Ninja NewNinja(string name, EnumMobType mobType) => BaseClassesAtributes.Ninja(new CreateCharacterDto(name, mobType));
}