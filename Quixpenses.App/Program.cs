using Quixpenses.App.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.ConfigureTelegramBotServices();
builder.ConfigureHostedServices();
builder.ConfigureDataAccessServices();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
