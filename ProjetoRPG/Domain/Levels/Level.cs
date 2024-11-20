using ProjetoRPG.Base;

namespace ProjetoRPG.Levels;

public class Level : BaseEntity
{
    public string LevelName { get; set; }
    public int MinLevel { get; set; } = 0;
    public IScene? FirstScene { get; set; }
    public double GoldReward { get; set; }
}