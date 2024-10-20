using ProjetoRPG.Classes.Base;

namespace ProjetoRPG.Game;

public class Player
{
    public Inventory Inventory { get; private set; }
    public Character Character { get; private set; }
}