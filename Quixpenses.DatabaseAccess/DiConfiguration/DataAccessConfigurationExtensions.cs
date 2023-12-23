using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Quixpenses.DatabaseAccess.Interfaces;
using Quixpenses.DatabaseAccess.Repositories.Categories;
using Quixpenses.DatabaseAccess.Repositories.Currencies;
using Quixpenses.DatabaseAccess.Repositories.Expenses;
using Quixpenses.DatabaseAccess.Repositories.Invites;
using Quixpenses.DatabaseAccess.Repositories.Users;

namespace Quixpenses.DatabaseAccess.DiConfiguration;

public static class DataAccessConfigurationExtensions
{
    public static IServiceCollection ConfigureDataAccess(this IServiceCollection services, string connectionString)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        dataSourceBuilder.EnableDynamicJson();

        var dataSource = dataSourceBuilder.Build();

        services.AddDbContext<EfContext>(
            options => options
                .UseLazyLoadingProxies()
                .UseNpgsql(dataSource));

        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IInvitesRepository, InvitesRepository>();
        services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
        services.AddScoped<IExpensesRepository, ExpensesRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}