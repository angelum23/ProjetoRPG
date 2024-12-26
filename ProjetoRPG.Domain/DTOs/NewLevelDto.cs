using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.Items;
using ProjetoRPG.Domain.Levels;

namespace ProjetoRPG.Domain.DTOs;

public class NewLevelDto
{
    public string Name { get; init; }
    public double GoldReward { get; init; }
    public List<NewSceneDto> Scenes { get; init; }

    public Level ToLevel() =>
        new Level
        {
            Name = Name,
            GoldReward = 100
        };
}

public class NewSceneDto
{
    public IScene Scene { get; init; }
    public NewCombatZoneDto? CombatZoneDto { get; init; }
}

public class NewCombatZoneDto
{
    public Character Enemy { get; set; }
    public NewCombatZoneLootDto? Loot { get; set; }
}

public class NewCombatZoneLootDto
{
    public Item Item { get; set; }
    public int DropPerc { get; set; }
}