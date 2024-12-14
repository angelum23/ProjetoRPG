using ProjetoRPG.Domain.Enums;

namespace ProjetoRPG.Infra;

public class Service
{
    public Type ServiceType { get; set; }
    public Type? InterfaceType { get; set; }
}

public class ServiceBuilder : Service
{
    public EnumServiceType EnumServiceType { get; set; }
}