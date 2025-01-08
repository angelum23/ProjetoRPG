using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Game;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Players;

public class PlayerConfig : BaseConfig<Player>
{
    public override void Configure(EntityTypeBuilder<Player> builder)
    {
        base.Configure(builder);
        
        builder.Int(p => p.IdInventory);
        builder.Int(p => p.IdCharacter);
        builder.Int(p => p.IdCurrentLevel);
        
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
               .HasForeignKey(p => p.IdCurrentLevel);
    }
}