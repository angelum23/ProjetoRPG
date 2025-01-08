using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Items;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Items;

public class ItemConfig : BaseConfig<Item>
{
    public override void Configure(EntityTypeBuilder<Item> builder)
    {
        base.Configure(builder);

        builder.String(i => i.Name);
        builder.String(i => i.Description);

        builder.Float(i => i.BuyPrice);
        
        builder.Enum(i => i.Rarity);
        builder.Enum(i => i.ItemType);
        
        builder.Float(i => i.BonusTotalHealth).HasDefaultValue(0);
        builder.Float(i => i.BonusRegeneration).HasDefaultValue(0);
        builder.Float(i => i.BonusArmor).HasDefaultValue(0);
        builder.Float(i => i.BonusMagicResist).HasDefaultValue(0);
        builder.Float(i => i.BonusAgility).HasDefaultValue(0);
        builder.Float(i => i.BonusTotalMana).HasDefaultValue(0);
        builder.Float(i => i.BonusManaRegeneration).HasDefaultValue(0);
        builder.Float(i => i.BonusDamage).HasDefaultValue(0);
        builder.Float(i => i.BonusAccuracy).HasDefaultValue(0);
        builder.Float(i => i.BonusRange).HasDefaultValue(0);
        builder.Float(i => i.BonusMagicDamage).HasDefaultValue(0);
        
        builder.Ignore(i => i.SellPrice);
    }
}