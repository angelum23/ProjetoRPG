using ProjetoRPG.Base;
using ProjetoRPG.Enums;
using ProjetoRPG.Repository;
using ProjetoRPG.Repository.Base;

namespace ProjetoRPG.Infra;

public class BuilderServices
{
    private static List<Service> GetSingletonList() =>
    [
        new Service { ServiceType = typeof(RepBaseMemory<>), InterfaceType = typeof(IRepBase<>)},
        new Service { ServiceType = typeof(RepCharacter) },
    ];
    
    private static List<Service> GetTransientList() =>
    [];
    
    private static List<Service> GetScopedList() =>
    [];
    
    #region GetAllAndAddServices
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

    public void AddService(ServiceBuilder serviceBuilder,  WebApplicationBuilder builder)
    {
        switch (serviceBuilder.EnumServiceType)
        {
            case EnumServiceType.Scoped:
                if (serviceBuilder.InterfaceType != null) 
                    builder.Services.AddScoped(serviceBuilder.ServiceType, serviceBuilder.InterfaceType);
                else
                    builder.Services.AddScoped(serviceBuilder.ServiceType);
                break;
        
            case EnumServiceType.Singleton:
                if (serviceBuilder.InterfaceType != null)
                    builder.Services.AddSingleton(serviceBuilder.ServiceType, serviceBuilder.InterfaceType);
                else
                    builder.Services.AddSingleton(serviceBuilder.ServiceType);
                break;
        
            case EnumServiceType.Transient:
                if (serviceBuilder.InterfaceType != null)
                    builder.Services.AddTransient(serviceBuilder.ServiceType, serviceBuilder.InterfaceType);
                else
                    builder.Services.AddTransient(serviceBuilder.ServiceType);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    #endregion
}