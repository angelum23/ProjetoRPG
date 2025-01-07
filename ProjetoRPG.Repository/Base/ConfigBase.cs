using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoRPG.Domain.Base;

namespace ProjetoRPG.Repository.Base;

public class ConfigBase<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        var tableName = typeof(T).Name.ToLower();
        builder.ToTable(tableName).HasKey(t => t.Id);
        
        builder.Property("Id").ValueGeneratedOnAdd();
        builder.Property("Removed").IsRequired().HasDefaultValue(false);
    }
}