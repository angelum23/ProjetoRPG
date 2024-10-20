using Microsoft.EntityFrameworkCore;
using ProjetoRPG.Enums;
using ProjetoRPG.Infra;

var builder = WebApplication.CreateBuilder(args);

// Adicionar a configuração do appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Configurar a conexão com o banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicione os serviços do seu projeto
// builder.Services.AddScoped<RepCharacter>();
BuilderServices builderServices = new();

foreach (var serviceTuple in builderServices.GetServiceList())
{
    switch (serviceTuple.Item1)
    {
        case EnumServiceType.Scoped:
            builder.Services.AddScoped(serviceTuple.Item2);
            break;
        case EnumServiceType.Singleton:
            builder.Services.AddSingleton(serviceTuple.Item2);
            break;
        case EnumServiceType.Transient:
            builder.Services.AddTransient(serviceTuple.Item2);
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
}

var app = builder.Build();

app.Run();