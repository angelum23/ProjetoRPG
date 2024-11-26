using ProjetoRPG.Classes.Base;
using ProjetoRPG.Enums;
using ProjetoRPG.Items.Base;
using ProjetoRPG.Repository;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class ServCharacter(RepCharacter rep, ServItem servItem) : BaseService<Character>(rep)
{
    public async Task<Character> EquipArmor(int idCharacter, int idItem)
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
}






















