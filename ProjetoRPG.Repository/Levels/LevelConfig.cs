using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Levels;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository.Levels;

public class LevelConfig : BaseConfig<Level>
{
    public override void Configure(EntityTypeBuilder<Level> builder)
    {
        base.Configure(builder);

        builder.String(l => l.Name);
        builder.Int(l => l.IdFirstScene);
        builder.Enum(l => l.FirstSceneType);
        builder.Int(l => l.IdActualScene);
        builder.Enum(l => l.ActualSceneType);
        builder.Float(l => l.GoldReward);
    }
}