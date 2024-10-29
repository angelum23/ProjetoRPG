using ProjetoRPG.Base;
using ProjetoRPG.Enums;
using ProjetoRPG.Repository;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Infra;

public class BuilderServices
{
    private static List<Service> GetSingletonList() =>
    [
        new Service { ServiceType = typeof(RepBase<>), InterfaceType = typeof(IRepBase<>)},
        new Service { ServiceType = typeof(RepCharacter) },
    ];
    
    private static List<Service> GetTransientList() =>
    [];
    
    private static List<Service> GetScopedList() =>
    [];
    
    public List<ServiceBuilder> GetServiceList() =>
    [
        ..GetSingletonList().Select(singletonService => new ServiceBuilder
        {
            EnumServiceType = EnumServiceType.Singleton,
            ServiceType = singletonService.ServiceType,
            InterfaceType = singletonService.InterfaceType
        }).ToList(),
        
        ..GetTransientList().Select(singletonService => new ServiceBuilder
        {
            EnumServiceType = EnumServiceType.Singleton,
            ServiceType = singletonService.ServiceType,
            InterfaceType = singletonService.InterfaceType
        }).ToList(),
        
        ..GetScopedList().Select(singletonService => new ServiceBuilder
        {
            EnumServiceType = EnumServiceType.Singleton,
            ServiceType = singletonService.ServiceType,
            InterfaceType = singletonService.InterfaceType
        }).ToList(),
    ];
}