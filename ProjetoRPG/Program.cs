using Microsoft.EntityFrameworkCore;
using ProjetoRPG.Enums;
using ProjetoRPG.Infra;

var builder = WebApplication.CreateBuilder(args);

#region AppSettings

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

#endregion

#region DatabaseConfiguration

// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region Services

BuilderServices builderServices = new();
var servicesBuilders = builderServices.GetServiceList();
servicesBuilders.ForEach(sb => builderServices.AddService(sb, builder));
builder.Services.AddControllers();

#endregion

var app = builder.Build();

#region Events configuration

ObserverBuilder.RegisterObservers(app.Services);

#endregion

app.MapControllers();
app.Run();