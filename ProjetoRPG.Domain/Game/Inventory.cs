using ProjetoRPG.Domain.Base;

namespace ProjetoRPG.Domain.Game;

public class Inventory : BaseEntity
{
    public int Capacity { get; set; } = 60;
    public double Gold { get; set; }
    
    //Equiped Items
    public int? IdEquippedArmor { get; set; }
    public int? IdEquippedWeapon { get; set; }
}