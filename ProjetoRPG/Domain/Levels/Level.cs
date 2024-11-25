using ProjetoRPG.Base;

namespace ProjetoRPG.Levels;

public class Level : BaseEntity
{
    public string Name { get; set; }
    public IScene? ActualScene { get; set; }
    public double GoldReward { get; set; }
}