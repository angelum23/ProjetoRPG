﻿using ProjetoRPG.Domain.Base;
using ProjetoRPG.Domain.Classes;
using ProjetoRPG.Domain.Enums;
using ProjetoRPG.Domain.Items;
using ProjetoRPG.Infra;

namespace ProjetoRPG.Classes.Base;

public class Character : BaseEntitySubject, ICharacter
{
    #region Constructor
    public Character(string name, 
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
                         float totalMana, 
                         float currentMana, 
                         float manaRegeneration,
                         float level,
                         float xpPerc,
                         EnumMobType mobType,
                         EnumClassType classType)
    {
        Name = name;
        Damage = damage;
        Accuracy = accuracy;
        Range = range;
        TotalHealth = totalHealth;
        CurrentHealth = currentHealth;
        Regeneration = regeneration;
        Armor = armor;
        MagicResist = magicResist;
        Agility = agility;
        MagicDamage = magicDamage;
        TotalMana = totalMana;
        CurrentMana = currentMana;
        ManaRegeneration = manaRegeneration;
        Level = level;
        XpPerc = xpPerc;
        MobType = mobType;
    }
    #endregion

    #region Properties
    public string Name { get; set; }
    public float Damage { get; set; }
    public float Accuracy { get; set; }
    public float Range { get; set; }
    
    public float TotalHealth { get; set; }
    public float CurrentHealth { get; set; }
    public bool IsAlive => CurrentHealth > 0;
    public float Regeneration { get; set; }
    public float Armor { get; set; }
    public float MagicResist { get; set; }
    public float Agility { get; set; }
    public float MagicDamage { get; set; }
    public float TotalMana  { get; set; }
    public float CurrentMana  { get; set; }
    public float ManaRegeneration { get; set; }
    public double Gold { get; set; }
    public float Level { get; set; }
    public float XpPerc { get; set; }
    public EnumMobType MobType { get; set; }
    public EnumClassType ClassType { get; set; }

    #endregion
    
    #region Methods
    public void RestoreAll()
    {
        CurrentHealth = TotalHealth;
        CurrentMana = TotalMana;
    }
    
    public void AddStatus(Item item)
    {
        TotalHealth += item.BonusTotalHealth;
        Regeneration += item.BonusRegeneration;
        Armor += item.BonusArmor;
        MagicResist += item.BonusMagicResist;
        Agility += item.BonusAgility;
        TotalMana += item.BonusTotalMana;
        ManaRegeneration += item.BonusManaRegeneration;
        Damage += item.BonusDamage;
        Accuracy += item.BonusAccuracy;
        Range += item.BonusRange;
        MagicDamage += item.BonusMagicDamage;
    }
    
    public void RemoveStatus(Item item)
    {
        TotalHealth -= item.BonusTotalHealth;
        Regeneration -= item.BonusRegeneration;
        Armor -= item.BonusArmor;
        MagicResist -= item.BonusMagicResist;
        Agility -= item.BonusAgility;
        TotalMana -= item.BonusTotalMana;
        ManaRegeneration -= item.BonusManaRegeneration;
        Damage -= item.BonusDamage;
        Accuracy -= item.BonusAccuracy;
        Range -= item.BonusRange;
        MagicDamage -= item.BonusMagicDamage;
    }
    public void ReceiveGold(int amount)
    {
        Gold += amount;
    }
    public void SpendGold(int amount)
    {
        Gold -= amount;
    }
    
    public virtual void AddXp(float xp)
    {
        XpPerc += xp;
        if (XpPerc >= 100)
        {
            LevelUp();
        }
    }
    
    public virtual void LevelUp()
    {
        Level++;
        XpPerc = 0;
        LevelUpStats();
    }
    
    public virtual void LevelUpStats()
    {
        TotalHealth *= 1.1f;
        TotalMana *= 1.1f;
        CurrentHealth = TotalHealth;
        CurrentHealth = TotalMana;
        Damage *= 1.1f;
        Regeneration *= 1.1f;
        Armor *= 1.1f;
        MagicResist *= 1.1f;
        Agility *= 1.1f;
        MagicDamage *= 1.1f;
        ManaRegeneration *= 1.1f;
    }
    #endregion
}