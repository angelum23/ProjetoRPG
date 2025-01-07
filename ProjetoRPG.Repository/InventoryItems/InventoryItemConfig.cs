using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Game;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.InventoryItems;

public class InventoryItemConfig : ConfigBase<InventoryItem>
{
    public override void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        base.Configure(builder);
        
        builder.Property(ii => ii.IdItem).IsRequired();
        builder.Property(ii => ii.IdInventory).IsRequired();
        
        builder.HasOne(ii => ii.Item)
               .WithMany()
               .HasForeignKey(ii => ii.IdItem)
               .IsRequired();

        builder.HasOne(ii => ii.Item)
               .WithMany()
               .HasForeignKey(ii => ii.IdItem)
               .IsRequired();
    }
}