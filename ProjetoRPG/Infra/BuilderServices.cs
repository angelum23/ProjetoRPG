using ProjetoRPG.Base;
using ProjetoRPG.Domain.Levels.Base;
using ProjetoRPG.Enums;
using ProjetoRPG.Game;
using ProjetoRPG.Levels.Base;
using ProjetoRPG.Repository;
using ProjetoRPG.Repository.Base;
using ProjetoRPG.Service;
using ProjetoRPG.Service.Base;
using ProjetoRPG.Service.Factory;

namespace ProjetoRPG.Infra;

public class BuilderServices
{
    private static List<Service> GetSingletonList() =>
    [
        new Service { ServiceType = typeof(RepBaseMemory<>), InterfaceType = typeof(IRepBase<>)},
        new Service { ServiceType = typeof(BaseService<BaseEntity>), InterfaceType = typeof(IBaseService<BaseEntity>)},
        new Service { ServiceType = typeof(SceneFactory), InterfaceType = typeof(ISceneService)},
        new Service { ServiceType = typeof(RepCharacter) },
        new Service { ServiceType = typeof(RepCombatZone)},
        new Service { ServiceType = typeof(RepInventory) },
        new Service { ServiceType = typeof(RepInventoryItem)},
        new Service { ServiceType = typeof(RepItem)},
        new Service { ServiceType = typeof(RepLevel) },
        new Service { ServiceType = typeof(RepPlayer)},
        new Service { ServiceType = typeof(RepStory)},
        new Service { ServiceType = typeof(SceneServiceFactory)},
        new Service { ServiceType = typeof(ServCharacter)},
        new Service { ServiceType = typeof(ServCombatZone)},
        new Service { ServiceType = typeof(ServInventory)},
        new Service { ServiceType = typeof(ServInventoryItem)},
        new Service { ServiceType = typeof(ServItem)},
        new Service { ServiceType = typeof(ServLevel)},
        new Service { ServiceType = typeof(ServPlayer)},
        new Service { ServiceType = typeof(ServStory)},
    ];
    
    private static List<Service> GetTransientList() =>
    [];
    
    private static List<Service> GetScopedList() =>
    [
        new Service{ ServiceType = typeof(Player) }
    ];
    
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
                    builder.Services.AddScoped(serviceBuilder.InterfaceType, serviceBuilder.ServiceType);
                else
                    builder.Services.AddScoped(serviceBuilder.ServiceType);
                break;
        
            case EnumServiceType.Singleton:
                if (serviceBuilder.InterfaceType != null)
                    builder.Services.AddSingleton(serviceBuilder.InterfaceType, serviceBuilder.ServiceType);
                else
                    builder.Services.AddSingleton(serviceBuilder.ServiceType);
                break;
        
            case EnumServiceType.Transient:
                if (serviceBuilder.InterfaceType != null)
                    builder.Services.AddTransient(serviceBuilder.InterfaceType, serviceBuilder.ServiceType);
                else
                    builder.Services.AddTransient(serviceBuilder.ServiceType);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    #endregion
}