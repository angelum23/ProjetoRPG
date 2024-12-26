using ProjetoRPG.Classes.Base;
using ProjetoRPG.Domain.Base;
using ProjetoRPG.Domain.Enums;
using ProjetoRPG.Domain.Items;

namespace ProjetoRPG.Domain.Levels;

public class CombatZone : BaseEntitySubject, IScene
{
    public string Name { get; set; }
    public string Description { get; set; }
    public EnumSceneType SceneType { get; set; } = EnumSceneType.CombatZone;
    
    public int? IdNextScene { get; set; }
    public IScene? NextScene { get; set; }
    
    public int IdEnemy { get; set; }
    public Character Enemy { get; set; }
    public int LootId { get; set; }
    public Item Loot { get; set; }
    public int DropPerc { get; set; } = 100;

    public int GetId()
    {
        return Id;
    }

    public bool Persisted() => Id > 0;
}