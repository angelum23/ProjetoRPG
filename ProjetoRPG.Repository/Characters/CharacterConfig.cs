using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Classes.Base;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Characters;

public class CharacterConfig : BaseConfig<Character>
{
    public override void Configure(EntityTypeBuilder<Character> builder)
    {
        base.Configure(builder);
        
        builder.Property(i => i.Name).IsRequired().HasMaxLength(255);

        builder.Enum(i => i.MobType);
        builder.Enum(i => i.ClassType);
        builder.Float(i => i.CharacterLevel).HasDefaultValue(1);
        builder.Float(i => i.XpPerc).HasDefaultValue(0);
        
        builder.Float(i => i.Damage).HasDefaultValue(1);
        builder.Float(i => i.Accuracy).HasDefaultValue(1);
        builder.Float(i => i.Range).HasDefaultValue(1);
        builder.Float(i => i.TotalHealth).HasDefaultValue(100);
        builder.Float(i => i.CurrentHealth).HasDefaultValue(100);
        builder.Float(i => i.Regeneration).HasDefaultValue(1);
        builder.Float(i => i.Armor).HasDefaultValue(1);
        builder.Float(i => i.MagicResist).HasDefaultValue(1);
        builder.Float(i => i.Agility).HasDefaultValue(1);
        builder.Float(i => i.MagicDamage).HasDefaultValue(0);
        builder.Float(i => i.TotalMana).HasDefaultValue(0);
        builder.Float(i => i.CurrentMana).HasDefaultValue(0);
        builder.Float(i => i.ManaRegeneration).HasDefaultValue(0);

        builder.Ignore(i => i.IsAlive);
    }
}