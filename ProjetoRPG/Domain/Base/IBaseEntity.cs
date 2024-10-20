namespace ProjetoRPG.Base;

public interface IBaseEntity
{
    public int Id { get; set; }
    public bool Removed { get; }
    public BaseEntity Remove();
    public BaseEntity Restore();
}