using ProjetoRPG.Domain.Base;
using ProjetoRPG.Domain.Items;

namespace ProjetoRPG.Domain.Game;

public class Inventory : BaseEntity
{
    public int Capacity { get; set; }
    public double Gold { get; set; }
    
    //Equiped Items
    public int? IdEquippedArmor { get; set; }
    public int? IdEquippedWeapon { get; set; }
    
    public Item EquippedArmor { get; set; }
    public Item EquippedWeapon { get; set; }
}