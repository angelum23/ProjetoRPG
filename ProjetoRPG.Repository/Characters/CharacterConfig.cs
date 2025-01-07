using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Classes.Base;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Characters;

public class CharacterConfig : ConfigBase<Character>
{
    public override void Configure(EntityTypeBuilder<Character> builder)
    {
        base.Configure(builder);
        
        builder.Property(i => i.Name).IsRequired().HasMaxLength(255);

        builder.Property(i => i.MobType).IsRequired().HasConversion<int>();
        builder.Property(i => i.ClassType).IsRequired().HasConversion<int>();
        builder.Property(i => i.Level).IsRequired().HasDefaultValue(1);
        builder.Property(i => i.XpPerc).IsRequired().HasDefaultValue(0);
        
        builder.Property(i => i.Damage).IsRequired().HasDefaultValue(1).HasPrecision(18,2);
        builder.Property(i => i.Accuracy).IsRequired().HasDefaultValue(1).HasPrecision(18,2);
        builder.Property(i => i.Range).IsRequired().HasDefaultValue(1).HasPrecision(18,2);
        builder.Property(i => i.TotalHealth).IsRequired().HasDefaultValue(100).HasPrecision(18,2);
        builder.Property(i => i.CurrentHealth).IsRequired().HasDefaultValue(100).HasPrecision(18,2);
        builder.Property(i => i.Regeneration).IsRequired().HasDefaultValue(1).HasPrecision(18,2);
        builder.Property(i => i.Armor).IsRequired().HasDefaultValue(1).HasPrecision(18,2);
        builder.Property(i => i.MagicResist).IsRequired().HasDefaultValue(1).HasPrecision(18,2);
        builder.Property(i => i.Agility).IsRequired().HasDefaultValue(1).HasPrecision(18,2);
        builder.Property(i => i.MagicDamage).IsRequired().HasDefaultValue(0).HasPrecision(18,2);
        builder.Property(i => i.TotalMana).IsRequired().HasDefaultValue(0).HasPrecision(18,2);
        builder.Property(i => i.CurrentMana).IsRequired().HasDefaultValue(0).HasPrecision(18,2);
        builder.Property(i => i.ManaRegeneration).IsRequired().HasDefaultValue(0).HasPrecision(18,2);

        builder.Ignore(i => i.IsAlive);
    }
}