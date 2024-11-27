using ProjetoRPG.Enums;

namespace ProjetoRPG.Infra.ObserverPattern;

public interface IObserver
{
    void Update(EnumObserverTrigger trigger);
}