using ProjetoRPG.Enums;
using ProjetoRPG.Items.Base;
using ProjetoRPG.Repository.Base;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class ItemService : BaseService<Item>
{
    private readonly IRepBase<Item>? _rep;

    private ItemService(IRepBase<Item>? rep) : base(rep)
    {
        _rep = rep;
    }
    
    public override async Task<Item> Save(Item item)
    {
        ValidarTiposDeItens(item);
        await base.Save(item);
        
        return item;
    }

    private void ValidarTiposDeItens(Item item)
    {
        switch (item.ItemType)
        {
            case EnumItemType.Sword:
                ValidarEspada(item);
                break;
            case EnumItemType.Armor:
                ValidarArmadura(item);
                break;
            //todo: adicionar validações para os outros tipos de item
        }
    }

    private void ValidarEspada(Item item)
    {
        if (item.BonusArmor > 0)
        {
            throw new Exception("Espada não pode ter bônus de armadura");
        }

        if (item.BonusRegeneration > 0)
        {
            throw new Exception("Espada não pode ter bônus de regeneração");
        }

        if (item.BonusMagicResist > 0)
        {
            throw new Exception("Espada não pode ter bônus de resistência mágica");
        }
        
        if(item.BonusTotalHealth > 0)
        {
            throw new Exception("Espada não pode ter bônus de vida");
        }
        
        if(item.BonusTotalMana > 0)
        {
            throw new Exception("Espada não pode ter bônus de mana");
        }
        
        if(item.BonusManaRegeneration > 0)
        {
            throw new Exception("Espada não pode ter bônus de regeneração de mana");
        }
    }

    private void ValidarArmadura(Item item)
    {
        //todo: adicionar validações para armadura
    }
}