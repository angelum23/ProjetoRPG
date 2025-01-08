using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoRPG.Infra;

public static class EntityTypeBuilderHelper
{
    public static PropertyBuilder<int> Int<TEntity>(
        this EntityTypeBuilder<TEntity> builder, 
        Expression<Func<TEntity, int>> propertyExpression) where TEntity : class
    {
        var propertyBuilder = builder.Property(propertyExpression);
        propertyBuilder.IsRequired();
        return propertyBuilder;
    }
    
    public static PropertyBuilder<int?> Int<TEntity>(
        this EntityTypeBuilder<TEntity> builder, 
        Expression<Func<TEntity, int?>> propertyExpression) where TEntity : class
    {
        var propertyBuilder = builder.Property(propertyExpression);
        return propertyBuilder;
    }

    public static PropertyBuilder<float> Float<TEntity>(
        this EntityTypeBuilder<TEntity> builder, 
        Expression<Func<TEntity, float>> propertyExpression) where TEntity : class
    {
        var propertyBuilder = builder.Property(propertyExpression);
        propertyBuilder.HasPrecision(18, 2).IsRequired();
        return propertyBuilder;
    }
    
    public static PropertyBuilder<float?> Float<TEntity>(
        this EntityTypeBuilder<TEntity> builder, 
        Expression<Func<TEntity, float?>> propertyExpression) where TEntity : class
    {
        var propertyBuilder = builder.Property(propertyExpression);
        propertyBuilder.HasPrecision(18, 2);
        return propertyBuilder;
    }

    public static PropertyBuilder<string> String<TEntity>(
        this EntityTypeBuilder<TEntity> builder, 
        Expression<Func<TEntity, string>> propertyExpression) where TEntity : class
    {
        var propertyBuilder = builder.Property(propertyExpression);
        propertyBuilder.HasMaxLength(255).HasDefaultValue().IsRequired();
        return propertyBuilder;
    }

    public static PropertyBuilder<TEnum> Enum<TEntity, TEnum>(
        this EntityTypeBuilder<TEntity> builder, 
        Expression<Func<TEntity, TEnum>> propertyExpression) where TEntity : class where TEnum : Enum
    {
        var propertyBuilder = builder.Property(propertyExpression);
        propertyBuilder.HasConversion<int>().IsRequired().HasDefaultValue(0);
        return propertyBuilder;
    }
}