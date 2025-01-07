using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Items;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Items;

public class ItemConfig : ConfigBase<Item>
{
    public override void Configure(EntityTypeBuilder<Item> builder)
    {
        base.Configure(builder);
        
        builder.Property(i => i.Name).IsRequired().HasMaxLength(255);
        builder.Property(i => i.Description).HasMaxLength(255);

        builder.Property(i => i.BuyPrice).IsRequired().HasPrecision(18, 2);
        
        builder.Property(i => i.Rarity).IsRequired().HasConversion<int>();
        builder.Property(i => i.ItemType).IsRequired().HasConversion<int>();
        
        builder.Property(i => i.BonusTotalHealth).HasPrecision(18,2).HasDefaultValue(0);
        builder.Property(i => i.BonusRegeneration).HasPrecision(18,2).HasDefaultValue(0);
        builder.Property(i => i.BonusArmor).HasPrecision(18,2).HasDefaultValue(0);
        builder.Property(i => i.BonusMagicResist).HasPrecision(18,2).HasDefaultValue(0);
        builder.Property(i => i.BonusAgility).HasPrecision(18,2).HasDefaultValue(0);
        builder.Property(i => i.BonusTotalMana).HasPrecision(18,2).HasDefaultValue(0);
        builder.Property(i => i.BonusManaRegeneration).HasPrecision(18,2).HasDefaultValue(0);
        builder.Property(i => i.BonusDamage).HasPrecision(18,2).HasDefaultValue(0);
        builder.Property(i => i.BonusAccuracy).HasPrecision(18,2).HasDefaultValue(0);
        builder.Property(i => i.BonusRange).HasPrecision(18,2).HasDefaultValue(0);
        builder.Property(i => i.BonusMagicDamage).HasPrecision(18,2).HasDefaultValue(0);
        
        builder.Ignore(i => i.SellPrice);
    }
}