using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.Classes;
using ProjetoRPG.Domain.DTOs;
using ProjetoRPG.Enums;

namespace ProjetoRPG.Classes;

public class BaseClassesAtributes
{
    public static Wizard Wizard(CreateCharacterDto dto)
    {
        return new Wizard(name: dto.Name,
                          damage: 1,
                          accuracy: 5,
                          range: 12,
                          totalHealth: 120,
                          currentHealth: 120,
                          regeneration: 1,
                          armor: 2,
                          magicResist: 10,
                          agility: 2,
                          magicDamage: 15,
                          totalMana: 120,
                          currentMana: 120,
                          manaRegeneration: 4,
                          level: 1,
                          xpPerc: 0,
                          mobType: dto.MobType);
    }

    public static Necromancer Necromancer(CreateCharacterDto dto)
    {
        return new Necromancer(name: dto.Name,
                               damage: 1,
                               accuracy: 3,
                               range: 10,
                               totalHealth: 100,
                               currentHealth: 100,
                               regeneration: 1,
                               armor: 2,
                               magicResist: 8,
                               agility: 2,
                               magicDamage: 9,
                               currentMana: 100,
                               totalMana: 100,
                               manaRegeneration: 6,
                               level: 1,
                               xpPerc: 0,
                               mobType: dto.MobType);
    }

    public static Ninja Ninja(CreateCharacterDto dto)
    {
        return new Ninja(name: dto.Name,
                         damage: 12,
                         accuracy: 8,
                         range: 2,
                         totalHealth: 180,
                         currentHealth: 180,
                         regeneration: 6,
                         armor: 5,
                         magicResist: 5,
                         agility: 15,
                         magicDamage: 0,
                         currentMana: 50, 
                         totalMana: 50,
                         manaRegeneration: 1,
                         level: 1,
                         xpPerc: 0,
                         mobType: dto.MobType);
    }

    public static Samurai Samurai(CreateCharacterDto dto)
    {
        return new Samurai(name: dto.Name,
                           damage: 20,
                           accuracy: 5,
                           range: 4,
                           totalHealth: 250,
                           currentHealth: 250,
                           regeneration: 8,
                           armor: 10,
                           magicResist: 2,
                           agility: 7,
                           magicDamage: 0,
                           currentMana: 0,
                           totalMana: 0,
                           manaRegeneration: 0,
                           level: 1,
                           xpPerc: 0,
                           mobType: dto.MobType);
    }

    public static Priest Priest(CreateCharacterDto dto)
    {
        return new Priest(name: dto.Name,
                           damage: 1,
                           accuracy: 3,
                           range: 8,
                           totalHealth: 140,
                           currentHealth: 140,
                           regeneration: 2,
                           armor: 2,
                           magicResist: 10,
                           agility: 2,
                           magicDamage: 7,
                           currentMana: 140,
                           totalMana: 140,
                           manaRegeneration: 8,
                           level: 1,
                           xpPerc: 0,
                           mobType: dto.MobType);
    }

    internal static Paladin Paladin(CreateCharacterDto dto)
    {
        return new Paladin(name: dto.Name,
                           damage: 15,
                           accuracy: 2,
                           range: 5,
                           totalHealth: 300,
                           currentHealth: 300,
                           regeneration: 5,
                           armor: 12,
                           magicResist: 6,
                           agility: 1,
                           magicDamage: 0,
                           currentMana: 70,
                           totalMana: 70,
                           manaRegeneration: 2,
                           level: 1,
                           xpPerc: 0,
                           mobType: dto.MobType);
    }
}