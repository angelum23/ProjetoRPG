using ProjetoRPG.Base;
using ProjetoRPG.Base.Enums;

namespace ProjetoRPG.Classes;

public class BaseClassesAtributes
{
    public static Character<Wizard> Wizard(string name, EnumMobType mobType = EnumMobType.Player)
    {
        return new Wizard(name, 1, 5, 5, 120, 120, 1, 2, 10, 2, 15, 120, 4, 1, 0, mobType);
    }

    public static Character<Necromancer> Necromancer(string name, EnumMobType mobType = EnumMobType.Player)
    {
        return new Necromancer(name, 1, 3, 10, 100, 100, 1, 2, 8, 2, 9, 100, 6, 1, 0, mobType);
    }
    
    public static Character<Ninja> Ninja(string name, EnumMobType mobType = EnumMobType.Player)
    {
        return new Ninja(name, 12, 8, 2, 180, 180, 6, 5, 5, 15, 0, 50, 1, 1, 0, mobType);
    }
}