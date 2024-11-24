using ProjetoRPG.Levels;

namespace ProjetoRPG.Domain.DTOs;

public class NewLevelDto(string Name, double GoldReward, List<IScene> Scenes)
{
    public string Name { get; init; } = Name;
    public double GoldReward { get; init; } = GoldReward;
    public List<IScene> Scenes { get; init; } = Scenes;

    public Level ToLevel() =>
        new Level
        {
            Name = Name,
            GoldReward = 100
        };
}