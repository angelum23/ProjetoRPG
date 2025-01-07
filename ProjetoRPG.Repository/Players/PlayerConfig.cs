using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Game;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Players;

public class PlayerConfig : ConfigBase<Player>
{
    public override void Configure(EntityTypeBuilder<Player> builder)
    {
        base.Configure(builder);
        
        builder.Property(p => p.IdInventory).IsRequired();
        builder.Property(p => p.IdCharacter).IsRequired();
        builder.Property(p => p.IdCurrentLevel).IsRequired();
        
        builder.HasOne(p => p.Inventory)
               .WithMany()
               .HasForeignKey(p => p.IdInventory)
               .IsRequired();

        builder.HasOne(p => p.Character)
               .WithMany()
               .HasForeignKey(p => p.IdCharacter)
               .IsRequired();

        builder.HasOne(p => p.CurrentLevel)
               .WithMany()
               .HasForeignKey(p => p.IdCurrentLevel)
               .IsRequired();
    }
}