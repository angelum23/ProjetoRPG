using ProjetoRPG.Base;
using ProjetoRPG.Enums;
using ProjetoRPG.Repository;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Infra;

public class BuilderServices
{
    public List<Tuple<EnumServiceType, Type>> GetServiceList() =>
    [
        ..GetSingletonList().Select(singletonService => new Tuple<EnumServiceType, Type>(EnumServiceType.Singleton, singletonService)),
        ..GetTransientList().Select(transientService => new Tuple<EnumServiceType, Type>(EnumServiceType.Transient, transientService)),
        ..GetScopedList().Select(scopedService => new Tuple<EnumServiceType, Type>(EnumServiceType.Scoped, scopedService))
    ];
    
    private List<Type> GetSingletonList() =>
    [
        typeof(RepCharacter)
    ];
    
    private List<Type> GetTransientList() =>
    [];
    
    private List<Type> GetScopedList() =>
    [];
}