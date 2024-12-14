using ProjetoRPG.Domain.Enums;
using ProjetoRPG.Domain.Items;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class ServItem(RepItem repItem, RepInventory repInventory) : BaseService<Item>(repItem)
{
    public override async Task<Item> SaveAsync(Item item)
    {
        ValidateItemTypes(item);
        await base.SaveAsync(item);
        
        return item;
    }
    
    public async Task<List<Item>> GetEquipments(int inventoryId)
    {
        var inventory = await repInventory.GetByIdAsync(inventoryId);
        if (!inventory.IdEquippedArmor.HasValue && !inventory.IdEquippedWeapon.HasValue)
        {
            throw new Exception("You have no equipment!");
        }
        
        var items = new List<Item>();
        if (inventory.IdEquippedArmor.HasValue)
        {
            items.Add(await repItem.GetByIdAsync(inventory.IdEquippedArmor.Value));
        }
        if (inventory.IdEquippedWeapon.HasValue)
        {
            items.Add(await repItem.GetByIdAsync(inventory.IdEquippedWeapon.Value));
        }

        return items;
    }

    private void ValidateItemTypes(Item item)
    {
        switch (item.ItemType)
        {
            case EnumItemType.Sword:
                ValidateSword(item);
                break;
            case EnumItemType.Armor:
                ValidateArmor(item);
                break;
            case EnumItemType.Bow:
                ValidateBow(item);
                break;
            case EnumItemType.Shield:
                ValidateShield(item);
                break;
            case EnumItemType.Staff:
                ValidateStaff(item);
                break;
        }
    }

    private void ValidateSword(Item item)
    {
        if (item.BonusArmor > 0) throw new Exception("Sword cannot have armor bonus");
        if (item.BonusRegeneration > 0) throw new Exception("Sword cannot have regeneration bonus");
        if (item.BonusMagicResist > 0) throw new Exception("Sword cannot have magic resistance bonus");
        if (item.BonusTotalHealth > 0) throw new Exception("Sword cannot have health bonus");
        if (item.BonusTotalMana > 0) throw new Exception("Sword cannot have mana bonus");
        if (item.BonusManaRegeneration > 0) throw new Exception("Sword cannot have mana regeneration bonus");
    }

    private void ValidateArmor(Item item)
    {
        if (item.BonusAgility > 0) throw new Exception("Armor cannot have agility bonus");
        if (item.BonusDamage > 0) throw new Exception("Armor cannot have damage bonus");
        if (item.BonusAccuracy > 0) throw new Exception("Armor cannot have accuracy bonus");
        if (item.BonusRange > 0) throw new Exception("Armor cannot have range bonus");
        if (item.BonusMagicDamage > 0) throw new Exception("Armor cannot have magic damage bonus");
    }

    private void ValidateBow(Item item)
    {
        if (item.BonusTotalHealth > 0) throw new Exception("Bow cannot have health bonus");
        if (item.BonusRegeneration > 0) throw new Exception("Bow cannot have regeneration bonus");
        if (item.BonusArmor > 0) throw new Exception("Bow cannot have armor bonus");
        if (item.BonusMagicResist > 0) throw new Exception("Bow cannot have magic resistance bonus");
        if (item.BonusTotalMana > 0) throw new Exception("Bow cannot have mana bonus");
        if (item.BonusManaRegeneration > 0) throw new Exception("Bow cannot have mana regeneration bonus");
        if (item.BonusMagicDamage > 0) throw new Exception("Bow cannot have magic damage bonus");
    }

    private void ValidateShield(Item item)
    {
        if (item.BonusTotalHealth > 0) throw new Exception("Shield cannot have health bonus");
        if (item.BonusRegeneration > 0) throw new Exception("Shield cannot have regeneration bonus");
        if (item.BonusAgility > 0) throw new Exception("Shield cannot have agility bonus");
        if (item.BonusTotalMana > 0) throw new Exception("Shield cannot have mana bonus");
        if (item.BonusManaRegeneration > 0) throw new Exception("Shield cannot have mana regeneration bonus");
        if (item.BonusDamage > 0) throw new Exception("Shield cannot have damage bonus");
        if (item.BonusAccuracy > 0) throw new Exception("Shield cannot have accuracy bonus");
        if (item.BonusRange > 0) throw new Exception("Shield cannot have range bonus");
        if (item.BonusMagicDamage > 0) throw new Exception("Shield cannot have magic damage bonus");
    }

    private void ValidateStaff(Item item)
    {
        if (item.BonusTotalHealth > 0) throw new Exception("Staff cannot have health bonus");
        if (item.BonusRegeneration > 0) throw new Exception("Staff cannot have regeneration bonus");
        if (item.BonusArmor > 0) throw new Exception("Staff cannot have armor bonus");
        if (item.BonusMagicResist > 0) throw new Exception("Staff cannot have magic resistance bonus");
        if (item.BonusDamage > 0) throw new Exception("Staff cannot have damage bonus");
    }

}
