using ProjetoRPG.Enums;

namespace ProjetoRPG.Domain.Classes;

public interface ICharacter
{
    string Name { get; protected set; }
    float Damage { get; protected set; }
    float Accuracy { get; protected set; }
    float Range { get; protected set; }
    
    float TotalHealth { get; protected set; }
    float CurrentHealth { get; }
    bool IsAlive => CurrentHealth > 0;
    float Regeneration { get; protected set; }
    float Armor { get; protected set; }
    float MagicResist { get; protected set; }
    float Agility { get; protected set; }
    float MagicDamage { get; protected set; }
    float TotalMana  { get; protected set; }
    float CurrentMana  { get; protected set; }
    float ManaRegeneration { get; protected set; }
    double Gold { get; protected set; }
    float Level { get; protected set; }
    float XpPerc { get; protected set; }
    EnumMobType MobType { get; protected set; }
    EnumClassType ClassType { get; protected set; }
}