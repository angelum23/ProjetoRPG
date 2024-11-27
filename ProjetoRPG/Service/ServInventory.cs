using ProjetoRPG.Enums;
using ProjetoRPG.Game;
using ProjetoRPG.Items.Base;
using ProjetoRPG.Repository;
using ProjetoRPG.Repository.Base;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class ServInventory(RepInventory rep, ServInventoryItem servInventoryItem, ServItem servItem, ServPlayer servPlayer, ServCharacter servCharacter) : BaseService<Inventory>(rep)
{
    private readonly List<EnumItemType> _weaponTypes = [EnumItemType.Sword, EnumItemType.Bow, EnumItemType.Staff, EnumItemType.Shield];
    
    public async Task AddItem(Inventory inventory, Item item)
    {
        var itensCount = await servInventoryItem.GetItensCountAsync(inventory);
        if (itensCount >= inventory.Capacity)
        {
            throw new Exception("Inventory is full");
        }
        
        var inventoryItem = new InventoryItem()
        {
            Inventory = inventory,
            Item = item
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

    public async Task EquipArmor(int idPlayer, int idItem)
    {
        var player = await servPlayer.GetByIdAsync(idPlayer);
        var item = await servItem.GetByIdAsync(idItem);
        var inventory = await base.GetByIdAsync(player.IdInventory);
        
        ValidateEquipArmor(item, inventory);
        
        await servCharacter.EquipArmorAsync(player.IdCharacter, idItem);
        inventory.IdEquippedArmor = idItem;
    }

    public async Task EquipWeapon(int idPlayer, int idItem)
    {
        var player = await servPlayer.GetByIdAsync(idPlayer);
        var item = await servItem.GetByIdAsync(idItem);
        var inventory = await base.GetByIdAsync(player.IdInventory);

        ValidateEquipWeapon(item, inventory);
        
        await servCharacter.EquipWeaponAsync(player.IdCharacter, idItem);
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