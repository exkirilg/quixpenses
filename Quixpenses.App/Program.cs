using Quixpenses.App.DIConfiguration;
using Quixpenses.DatabaseAccess.DiConfiguration;
using Quixpenses.Services.DiConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureTelegramBotOptions();

builder.Services
    .ConfigureDataAccess(builder.Configuration.GetConnectionString("Db")!)
    .ConfigureServices()
    .ConfigureTelegramBotHttpClient()
    .ConfigureUpdatesHandling()
    .ConfigureHostedServices()
    .AddControllers()
    .AddNewtonsoftJson();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
