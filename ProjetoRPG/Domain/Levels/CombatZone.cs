using ProjetoRPG.Actions;
using ProjetoRPG.Classes.Base;
using ProjetoRPG.Enums;
using ProjetoRPG.Game;
using ProjetoRPG.Items.Base;

namespace ProjetoRPG.Levels;

public class CombatZone : Scene
{
    public CombatZone(int idScene, string name, string description, EnumSceneType sceneType, Scene nextScene, int idCharacter, Player player, Character enemy, int dropPerc, List<Item> loots) : base(idScene, name, description, sceneType, nextScene)
    {
        IdCharacter = idCharacter;
        Player = player;
        Enemy = enemy;
        DropPerc = dropPerc;
        Loots = loots;
    }

    public int IdCharacter { get; set; }
    public Player Player { get; set; }
    public Character Enemy { get; set; }
    public int DropPerc { get; set; } = 100;
    public List<Item> Loots { get; set; }


    public override void Act()
    {
        //Todo: Implementar a lógica de combate
        Player.Character.Attack(Enemy);
    }

    public override void StartScene()
    {
        var combat = new Combat()
        {
            Character = this.Player.Character,
            Enemy = Enemy
        };
        //todo: Implementar a lógica de exibir o início do combate
    }

    public override void EndScene()
    {
        var zoneName = Name.Length > 0 ? (Name + " ") : "";
        Console.WriteLine($"CombatZone {zoneName}was cleared");
        
        if (Random.Shared.Next(0, 100) <= DropPerc)
        {
            return;
        }
        
        var drop = ItemHelper.DropItemBasedOnChance(Loots);
        if (drop == null)
        {
            return;
        }
        
        Console.WriteLine($"Dropped {drop.Name}");
        Player.Inventory.AddItem(drop);
    }
}