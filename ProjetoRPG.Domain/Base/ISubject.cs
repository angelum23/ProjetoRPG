namespace ProjetoRPG.Domain.Base;

public interface ISubject
{
    void RegistrarObservador(IObserver observador);
    void RemoverObservador(IObserver observador);
    void NotificarObservadores();
}

