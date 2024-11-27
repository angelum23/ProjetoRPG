using ProjetoRPG.Actions;
using ProjetoRPG.Base;
using ProjetoRPG.Classes.Base;
using ProjetoRPG.Enums;
using ProjetoRPG.Game;
using ProjetoRPG.Items.Base;

namespace ProjetoRPG.Levels;

public class CombatZone : BaseEntity, IScene
{
    public string Name { get; set; }
    public string Description { get; set; }
    public EnumSceneType SceneType { get; set; } = EnumSceneType.CombatZone;
    
    public int? IdNextScene { get; set; }
    public IScene? NextScene { get; set; }
    
    public int IdEnemy { get; set; }
    public Character Enemy { get; set; }
    public int DropPerc { get; set; } = 100;
    public Item Loot { get; set; }

    public int GetId()
    {
        return Id;
    }

    public bool Persisted() => Id > 0;
}