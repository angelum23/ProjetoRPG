using ProjetoRPG.Base;

namespace ProjetoRPG.Levels;

public interface IArea
{
    List<LevelEnemy> Enemies { get; set; }
}