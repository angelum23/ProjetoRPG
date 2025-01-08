using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Levels;
using ProjetoRPG.Infra;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Repository;

public class StoryConfig : BaseConfig<Story>
{
    public override void Configure(EntityTypeBuilder<Story> builder)
    {
        base.Configure(builder);
        
        builder.String(i => i.Name);
        builder.String(i => i.Description);
        builder.Enum(i => i.SceneType);
        builder.Int(i => i.IdNextScene);
        
        builder.HasOne(i => i.NextScene).WithMany().HasForeignKey(i => i.IdNextScene);
    }
}