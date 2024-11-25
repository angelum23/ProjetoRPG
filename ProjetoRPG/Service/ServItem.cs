using ProjetoRPG.Enums;
using ProjetoRPG.Items.Base;
using ProjetoRPG.Repository;
using ProjetoRPG.Repository.Base;
using ProjetoRPG.Service.Base;

namespace ProjetoRPG.Service;

public class ServItem : BaseService<Item>
{
    private readonly RepItem _rep;

    private ServItem(RepItem rep) : base(rep)
    {
        _rep = rep;
    }
    
    public override async Task<Item> SaveAsync(Item item)
    {
        ValidarTiposDeItens(item);
        await base.SaveAsync(item);
        
        return item;
    }
    
    public async Task<Item> GetEquipments(int inventoryId)
    {
        return _rep.GetEquipments(inventoryId);
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
            case EnumItemType.Bow:
                ValidarArco(item);
                break;
            case EnumItemType.Shield:
                ValidarEscudo(item);
                break;
            case EnumItemType.Staff:
                ValidarCajado(item);
                break;
        }
    }

    private void ValidarEspada(Item item)
    {
        if (item.BonusArmor > 0) throw new Exception("Espada não pode ter bônus de armadura");
        if (item.BonusRegeneration > 0) throw new Exception("Espada não pode ter bônus de regeneração");
        if (item.BonusMagicResist > 0) throw new Exception("Espada não pode ter bônus de resistência mágica");
        if (item.BonusTotalHealth > 0) throw new Exception("Espada não pode ter bônus de vida");
        if (item.BonusTotalMana > 0) throw new Exception("Espada não pode ter bônus de mana");
        if (item.BonusManaRegeneration > 0) throw new Exception("Espada não pode ter bônus de regeneração de mana");
    }

    private void ValidarArmadura(Item item)
    {
        if (item.BonusAgility > 0) throw new Exception("Armadura não pode ter bônus de agilidade");
        if (item.BonusDamage > 0) throw new Exception("Armadura não pode ter bônus de dano");
        if (item.BonusAccuracy > 0) throw new Exception("Armadura não pode ter bônus de precisão");
        if (item.BonusRange > 0) throw new Exception("Armadura não pode ter bônus de alcance");
        if (item.BonusMagicDamage > 0) throw new Exception("Armadura não pode ter bônus de dano mágico");
    }

    private void ValidarArco(Item item)
    {
        if (item.BonusTotalHealth > 0) throw new Exception("Arco não pode ter bônus de vida");
        if (item.BonusRegeneration > 0) throw new Exception("Arco não pode ter bônus de regeneração");
        if (item.BonusArmor > 0) throw new Exception("Arco não pode ter bônus de armadura");
        if (item.BonusMagicResist > 0) throw new Exception("Arco não pode ter bônus de resistência mágica");
        if (item.BonusTotalMana > 0) throw new Exception("Arco não pode ter bônus de mana");
        if (item.BonusManaRegeneration > 0) throw new Exception("Arco não pode ter bônus de regeneração de mana");
        if (item.BonusMagicDamage > 0) throw new Exception("Arco não pode ter bônus de dano mágico");
    }

    private void ValidarEscudo(Item item)
    {
        if (item.BonusTotalHealth > 0) throw new Exception("Escudo não pode ter bônus de vida");
        if (item.BonusRegeneration > 0) throw new Exception("Escudo não pode ter bônus de regeneração");
        if (item.BonusAgility > 0) throw new Exception("Escudo não pode ter bônus de agilidade");
        if (item.BonusTotalMana > 0) throw new Exception("Escudo não pode ter bônus de mana");
        if (item.BonusManaRegeneration > 0) throw new Exception("Escudo não pode ter bônus de regeneração de mana");
        if (item.BonusDamage > 0) throw new Exception("Escudo não pode ter bônus de dano");
        if (item.BonusAccuracy > 0) throw new Exception("Escudo não pode ter bônus de precisão");
        if (item.BonusRange > 0) throw new Exception("Escudo não pode ter bônus de alcance");
        if (item.BonusMagicDamage > 0) throw new Exception("Escudo não pode ter bônus de dano mágico");
    }

    private void ValidarCajado(Item item)
    {
        if (item.BonusTotalHealth > 0) throw new Exception("Cajado não pode ter bônus de vida");
        if (item.BonusRegeneration > 0) throw new Exception("Cajado não pode ter bônus de regeneração");
        if (item.BonusArmor > 0) throw new Exception("Cajado não pode ter bônus de armadura");
        if (item.BonusMagicResist > 0) throw new Exception("Cajado não pode ter bônus de resistência mágica");
        if (item.BonusDamage > 0) throw new Exception("Cajado não pode ter bônus de dano");
    }
}
