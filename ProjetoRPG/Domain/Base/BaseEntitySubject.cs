using ProjetoRPG.Enums;
using ProjetoRPG.Infra.ObserverPattern;

namespace ProjetoRPG.Base;

public class BaseEntitySubject : BaseEntity
{
    private readonly List<IObserver> _observers = [];
    
    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }
    
    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }
    
    public async Task NotifyObservers(EnumObserverTrigger trigger, int? id = null)
    {
        foreach (var observer in _observers)
        {
            await observer.Update(trigger, id);
        }
    }
}