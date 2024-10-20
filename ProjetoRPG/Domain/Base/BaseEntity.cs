namespace ProjetoRPG.Base;

public abstract class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public bool Removed { get; private set; }
    
    public BaseEntity Remove()
    {
        Removed = true;
        return this;
    }
    
    public BaseEntity Restore()
    {
        Removed = false;
        return this;
    }
}