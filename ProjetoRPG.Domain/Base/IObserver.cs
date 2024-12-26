using ProjetoRPG.Domain.Enums;

namespace ProjetoRPG.Domain.Base;

public interface IObserver
{
    Task Update(EnumObserverTrigger trigger, int? id = null);
}