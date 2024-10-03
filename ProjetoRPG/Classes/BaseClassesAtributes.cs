using ProjetoRPG.Base;
using ProjetoRPG.Base.Enums;
using System.Reflection.Emit;

namespace ProjetoRPG.Classes;

public class BaseClassesAtributes
{
    public static Wizard Wizard(string name, EnumMobType mobType = EnumMobType.Player)
    {
        return new Wizard(name: name,
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
                          mobType: mobType);
    }

    public static Necromancer Necromancer(string name, EnumMobType mobType = EnumMobType.Player)
    {
        return new Necromancer(name: name,
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
                               mobType: mobType);
    }

    public static Ninja Ninja(string name, EnumMobType mobType = EnumMobType.Player)
    {
        return new Ninja(name: name,
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
                         mobType: mobType);
    }

    public static Samurai Samurai(string name, EnumMobType mobType)
    {
        return new Samurai(name: name,
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
                           mobType: mobType);
    }

    public static Priest Priest(string name, EnumMobType mobType)
    {
        return new Priest(name: name,
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
                           mobType: mobType);
    }

    internal static Paladin Paladin(string name, EnumMobType mobType)
    {
        return new Paladin(name: name,
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
                           mobType: mobType);
    }
}