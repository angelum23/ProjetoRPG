using ProjetoRPG.Base;

namespace ProjetoRPG.Player;

public class Player
{
    public Inventory Inventory { get; private set; }
    public Character Character { get; private set; }
}