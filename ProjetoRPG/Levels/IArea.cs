using ProjetoRPG.Base;

namespace ProjetoRPG.Levels;

public interface IArea
{
    List<LevelCharacter> Enemies { get; set; }
}