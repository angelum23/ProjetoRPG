using ProjetoRPG.Base;
using ProjetoRPG.Enums;
using ProjetoRPG.Infra.ObserverPattern;

namespace ProjetoRPG.Levels;

public class Level : BaseEntitySubject, IObserver
{
    public string Name { get; set; }
    public EnumSceneType SceneType { get; set; }
    public int IdFirstScene { get; set; }
    public EnumSceneType FirstSceneType { get; set; }
    public int IdActualScene { get; set; }
    public EnumSceneType ActualSceneType { get; set; }
    public double GoldReward { get; set; }
    
    public async Task Update(EnumObserverTrigger trigger, int? id = null)
    {
        await NotifyObservers(trigger, this.Id);
    }
}