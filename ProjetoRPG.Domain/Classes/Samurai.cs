using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.Classes.Base;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Domain.Enums;

namespace ProjetoRPG.Domain.Classes;

public class Samurai : Character
{
    public Samurai(string name, 
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
               EnumClassType.Samurai)
    {}

    public Samurai NewSamurai(string name, EnumMobType mobType) => BaseClassesAtributes.Samurai(new CreateCharacterDto(name, mobType));
}