using ProjetoRPG.Base.Enums;

namespace ProjetoRPG.Base;

public class Character
{
    #region Constructor
    protected Character(string name, 
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
                     EnumMobType mobType)
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
    public string Name { get; protected set; }
    public float Damage { get; protected set; }
    public float Accuracy { get; protected set; }
    public float Range { get; protected set; }
    
    public float TotalHealth { get; protected set; }
    public float CurrentHealth { get; protected set; }
    public bool IsAlive => CurrentHealth > 0;
    public float Regeneration { get; protected set; }
    public float Armor { get; protected set; }
    public float MagicResist { get; protected set; }
    public float Agility { get; protected set; }
    public float MagicDamage { get; protected set; }
    public float TotalMana  { get; protected set; }
    public float CurrentMana  { get; protected set; }
    public float ManaRegeneration { get; protected set; }
    
    public float Level { get; protected set; }
    public float XpPerc { get; protected set; }
    public EnumMobType MobType { get; protected set; }

    #endregion
    
    #region Methods
    public virtual void Defend(Character enemy)
    {
        float damageTaken = Math.Max(0, enemy.Damage - Armor);
        CurrentHealth -= damageTaken;
    }

    public virtual void MagicDefend(Character enemy)
    {
        float damageTaken = Math.Max(0, enemy.MagicDamage - MagicResist);
        CurrentHealth -= damageTaken;
    }
    
    public virtual void Attack(Character enemy)
    {
        if (!HitSuccessfully(enemy))
        {
            Console.WriteLine("Miss!");
            return;
        }
        
        enemy.Defend(this);
    }

    public virtual float HitChance(float enemyAgility)
    {
        return (Accuracy / (Accuracy + enemyAgility)) * 100;
    }

    public virtual bool HitSuccessfully(Character enemy)
    {
        var roll = (float)Random.Shared.NextDouble() * 100;
        return roll <= HitChance(enemy.Agility);
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