using Quixpenses.App.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.ConfigureServices();
builder.ConfigureHostedServices();
builder.ConfigureDataAccess();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
