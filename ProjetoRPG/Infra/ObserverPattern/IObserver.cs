using ProjetoRPG.Enums;

namespace ProjetoRPG.Infra.ObserverPattern;

public interface IObserver
{
    Task Update(EnumObserverTrigger trigger, int? id = null);
}