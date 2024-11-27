namespace ProjetoRPG.Infra.ObserverPattern;

public interface ISubject
{
    void RegistrarObservador(IObserver observador);
    void RemoverObservador(IObserver observador);
    void NotificarObservadores();
}

