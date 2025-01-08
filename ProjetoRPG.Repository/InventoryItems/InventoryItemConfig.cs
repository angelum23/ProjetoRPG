using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Game;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.InventoryItems;

public class InventoryItemConfig : BaseConfig<InventoryItem>
{
    public override void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        base.Configure(builder);
        
        builder.Int(ii => ii.IdItem);
        builder.Int(ii => ii.IdInventory);
        
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