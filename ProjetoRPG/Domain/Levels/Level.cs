namespace ProjetoRPG.Levels;

public class Level
{
    public string LevelName { get; set; }
    public int MinLevel { get; set; } = 0;
    public List<CombatZone> Zones = [];
}