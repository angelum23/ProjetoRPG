using ProjetoRPG.Domain.Base;
using ProjetoRPG.Domain.Enums;

namespace ProjetoRPG.Domain.Levels;

public class Level : BaseEntity
{
    public string Name { get; set; }
    public EnumSceneType SceneType { get; set; }
    public int IdFirstScene { get; set; }
    public EnumSceneType FirstSceneType { get; set; }
    public int IdActualScene { get; set; }
    public EnumSceneType ActualSceneType { get; set; }
    public double GoldReward { get; set; }
}