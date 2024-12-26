using Microsoft.EntityFrameworkCore;
using ProjetoRPG.Domain.Game;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class ServInventoryItem(RepInventoryItem rep) : BaseService<InventoryItem>(rep)
{
    public async Task<int> GetItensCountAsync(Inventory inventory)
    {
        return await Get().CountAsync(x => x.Inventory.Id == inventory.Id);
    }

    public async Task<InventoryItem> GetByInventoryAndItemAsync(int inventoryId, int itemId)
    {
        return await Get().FirstAsync(x => x.Inventory.Id == inventoryId
                                                   && x.Item.Id == itemId);
    }

    public async Task<List<InventoryItem>> GetByInventoryAsync(int idInventory)
    {
        return await Get().Where(x => x.Inventory.Id == idInventory).ToListAsync();
    }
}