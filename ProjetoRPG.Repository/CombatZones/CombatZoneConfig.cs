using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Levels;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.CombatZones;

public class CombatZoneConfig : BaseConfig<CombatZone>
{
    public override void Configure(EntityTypeBuilder<CombatZone> builder)
    {
        base.Configure(builder);
        
        builder.String(i => i.Name);
        builder.String(i => i.Description);
        builder.Enum(i => i.SceneType);
        builder.Int(i => i.IdNextScene);
        builder.Int(i => i.IdEnemy);
        builder.Int(i => i.IdLoot);
        builder.Float(i => i.DropPerc);
        
        builder.HasOne(i => i.NextScene).WithMany().HasForeignKey(i => i.IdNextScene);
        builder.HasOne(i => i.Enemy).WithMany().HasForeignKey(i => i.IdEnemy);
        builder.HasOne(i => i.Loot).WithMany().HasForeignKey(i => i.IdLoot);
    }
}