using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.Enums;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class ServCharacter(RepCharacter rep, ServItem servItem) : BaseServiceSubject<Character>(rep)
{
    public async Task<Character> EquipArmorAsync(int idCharacter, int idItem)
    {
        var character = await rep.GetByIdAsync(idCharacter);
        var item = await servItem.GetByIdAsync(idItem);

        if (item.ItemType != EnumItemType.Armor)
        {
            throw new Exception("Item is not armor");
        }
        
        character.AddStatus(item);
        
        await rep.SaveAsync(character);
        return character;
    }
    
    public async Task<Character> UnequipArmor(int idCharacter, int idItem)
    {
        var character = await rep.GetByIdAsync(idCharacter);
        var item = await servItem.GetByIdAsync(idItem);

        if (item.ItemType != EnumItemType.Armor)
        {
            throw new Exception("Item is not armor");
        }
        
        character.RemoveStatus(item);
        
        await rep.SaveAsync(character);
        return character;
    }
    
    public async Task<Character> EquipWeaponAsync(int idCharacter, int idItem)
    {
        var character = await rep.GetByIdAsync(idCharacter);
        var item = await servItem.GetByIdAsync(idItem);

        if (item.ItemType == EnumItemType.Armor)
        {
            throw new Exception("Item is not weapon");
        }
        
        character.AddStatus(item);
        
        await rep.SaveAsync(character);
        return character;
    }
    
    public async Task<Character> UnequipWeapon(int idCharacter, int idItem)
    {
        var character = await rep.GetByIdAsync(idCharacter);
        var item = await servItem.GetByIdAsync(idItem);

        if (item.ItemType == EnumItemType.Armor)
        {
            throw new Exception("Item is not weapon");
        }
        
        character.RemoveStatus(item);
        
        await rep.SaveAsync(character);
        return character;
    }

    #region FromCharacter
    public virtual void TakeDamage(Character character, float damage)
    {
        var damageTaken = Math.Max(0, damage);
        character.CurrentHealth -= damageTaken;

        OnDeath(character);
    }
    
    public virtual void Attack(Character character, Character enemy)
    {
        if (!HitSuccessfully(character, enemy))
        {
            Console.WriteLine("Miss!");
            return;
        }
        
        TakeDamage(enemy, character.Damage / enemy.Armor);
    }

    public virtual void MagicAtack(Character enemy)
    {
        Console.WriteLine("Casted a nothing ball!");
    }

    public virtual float HitChance(Character character, float enemyAgility)
    {
        return (character.Accuracy / (character.Accuracy + enemyAgility)) * 100;
    }

    public virtual bool HitSuccessfully(Character character, Character enemy)
    {
        var roll = (float)Random.Shared.NextDouble() * 100;
        return roll <= HitChance(character, enemy.Agility);
    }
    
    private void OnDeath(Character character)
    {
        if (character.CurrentHealth > 0) return;
        
        character.RestoreAll();
        
        var trigger = character.MobType == EnumMobType.Player
            ? EnumObserverTrigger.OnPlayerCharacterDeath
            : EnumObserverTrigger.OnEnemyCharacterDeath;
            
        AsyncHelper.FireAndForget(NotifyObservers(trigger, character.Id));
    }

    #endregion
}