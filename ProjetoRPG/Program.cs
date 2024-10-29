using Microsoft.EntityFrameworkCore;
using ProjetoRPG.Enums;
using ProjetoRPG.Infra;

var builder = WebApplication.CreateBuilder(args);

// Adicionar a configuração do appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Configurar a conexão com o banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

BuilderServices builderServices = new();
foreach (var serviceBuilder in builderServices.GetServiceList())
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

var app = builder.Build();

app.Run();