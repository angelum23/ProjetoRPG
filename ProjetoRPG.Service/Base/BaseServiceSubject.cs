using ProjetoRPG.Domain.Base;
using ProjetoRPG.Domain.Enums;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Service.Base;

public class BaseServiceSubject<T>(IRepBase<T> rep) : BaseService<T>(rep) where T : BaseEntity
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