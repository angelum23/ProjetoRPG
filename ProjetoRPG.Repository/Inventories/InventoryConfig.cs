using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Game;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Inventories;

public class InventoryConfig : ConfigBase<Inventory>
{
    public override void Configure(EntityTypeBuilder<Inventory> builder)
    {
        base.Configure(builder);

        builder.Property(i => i.Capacity).IsRequired().HasDefaultValue(60);
        builder.Property(i => i.Gold).IsRequired().HasDefaultValue(0);
        builder.Property(i => i.IdEquippedArmor);
        builder.Property(i => i.IdEquippedWeapon);

        builder.HasOne(i => i.EquippedArmor)
               .WithMany()
               .HasForeignKey(p => p.IdEquippedArmor);
        
        builder.HasOne(i => i.EquippedWeapon)
               .WithMany()
                .HasForeignKey(p => p.IdEquippedWeapon);
    }
}