using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Game;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Inventories;

public class InventoryConfig : BaseConfig<Inventory>
{
    public override void Configure(EntityTypeBuilder<Inventory> builder)
    {
        base.Configure(builder);

        builder.Int(i => i.Capacity).HasDefaultValue(60);
        builder.Float(i => i.Gold).HasDefaultValue(0);
        builder.Int(i => i.IdEquippedArmor);
        builder.Int(i => i.IdEquippedWeapon);

        builder.HasOne(i => i.EquippedArmor)
               .WithMany()
               .HasForeignKey(p => p.IdEquippedArmor);
        
        builder.HasOne(i => i.EquippedWeapon)
               .WithMany()
                .HasForeignKey(p => p.IdEquippedWeapon);
    }
}