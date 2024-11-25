using ProjetoRPG.Items.Base;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository;

public class RepItem(RepInventory repInventory) : RepBaseMemory<Item>
{
    public Item GetEquipments(int inventoryId)
    {
        // return from p in Get<Item>()
        //     join i in repInventory.Get() on p.IdInventory equals i.Id
        //     where p.Id == playerId
        //     select new
        //     {
        //         Armor = i.IdEquippedArmor,
        //         Weapon = i.IdEquippedWeapon
        //     };
        throw new NotImplementedException();
    }
}