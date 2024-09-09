using ProjetoRPG.Base.Enums;

namespace ProjetoRPG.Base;

public class Level
{
    #region Constructor
    protected Level(string name, 
                 EnumLevelType levelType, 
                 int levelMinXp, 
                 List<Character> mobs)
    {
        Name = name;
        LevelType = levelType;
        LevelMinXp = levelMinXp;
        Mobs = mobs;
    }
    #endregion
    
    public string Name { get; protected set; }
    public EnumLevelType LevelType { get; protected set; }
    public int LevelMinXp { get; protected set; }
    public List<Character> Mobs { get; protected set; }
}