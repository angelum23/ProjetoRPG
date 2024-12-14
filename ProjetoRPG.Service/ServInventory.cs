using ProjetoRPG.Domain.Enums;
using ProjetoRPG.Domain.Game;
using ProjetoRPG.Domain.Items;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class ServInventory(RepInventory rep, ServInventoryItem servInventoryItem, ServItem servItem, ServCharacter servCharacter) : BaseService<Inventory>(rep)
{
    private readonly List<EnumItemType> _weaponTypes = [EnumItemType.Sword, EnumItemType.Bow, EnumItemType.Staff, EnumItemType.Shield];
    
    public async Task AddItem(Inventory inventory, int idItem)
    {
        var itensCount = await servInventoryItem.GetItensCountAsync(inventory);
        if (itensCount >= inventory.Capacity)
        {
            throw new Exception("Inventory is full");
        }
        
        var inventoryItem = new InventoryItem()
        {
            IdInventory = inventory.Id,
            IdItem = idItem
        };

        await servInventoryItem.SaveAsync(inventoryItem);
    }

    public async Task DropItemAsync(Inventory inventory, Item item)
    {
        var inventoryItem = servInventoryItem.GetByInventoryAndItemAsync(inventory.Id, item.Id);
        if (inventoryItem == null)
        {
            throw new Exception("Item not found in inventory");
        }
        
        if(inventory.IdEquippedArmor == item.Id)
        {
            inventory.IdEquippedArmor = null;
        }
        if(inventory.IdEquippedArmor == item.Id)
        {
            inventory.IdEquippedArmor = null;
        }
        
        await servInventoryItem.RemoveAsync(inventoryItem.Id);
    }

    public async Task<List<Item>> OpenInventoryAsync(int idInventory)
    {
        var inventoryItens = await servInventoryItem.GetByInventoryAsync(idInventory);
        return inventoryItens.Select(x => x.Item).ToList();
    }

    public async Task EquipArmor(int idInventory, int idCharacter, int idItem)
    {
        var item = await servItem.GetByIdAsync(idItem);
        var inventory = await base.GetByIdAsync(idInventory);
        
        ValidateEquipArmor(item, inventory);
        
        await servCharacter.EquipArmorAsync(idCharacter, idItem);
        inventory.IdEquippedArmor = idItem;
    }

    public async Task EquipWeapon(int idInventory, int idCharacter, int idItem)
    {
        var item = await servItem.GetByIdAsync(idItem);
        var inventory = await base.GetByIdAsync(idInventory);

        ValidateEquipWeapon(item, inventory);
        
        await servCharacter.EquipWeaponAsync(idCharacter, idItem);
        inventory.IdEquippedWeapon = idItem;
    }

    private void ValidateEquipWeapon(Item item, Inventory inventory)
    {
        if (!_weaponTypes.Contains(item.ItemType))
        {
            throw new Exception("Item is not a weapon");
        }
        
        if (inventory.IdEquippedWeapon != null)
        {
            throw new Exception("Player already has a weapon equipped");
        }
    }
    
    private void ValidateEquipArmor(Item item, Inventory inventory)
    {
        if (item.ItemType != EnumItemType.Armor)
        {
            throw new Exception("Item is not an armor");
        }
        
        if (inventory.IdEquippedArmor != null)
        {
            throw new Exception("Player already has an armor equipped");
        }
    }
}