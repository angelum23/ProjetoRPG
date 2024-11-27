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
    
    public void NotifyObservers(EnumObserverTrigger trigger)
    {
        foreach (var observer in _observers)
        {
            observer.Update(trigger);
        }
    }

}