using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quixpenses.DatabaseAccess.Repositories.Categories;
using Quixpenses.DatabaseAccess.Repositories.Currencies;
using Quixpenses.DatabaseAccess.Repositories.Invites;
using Quixpenses.DatabaseAccess.Repositories.Transactions;
using Quixpenses.DatabaseAccess.Repositories.Users;

namespace Quixpenses.DatabaseAccess.DiConfiguration;

public static class DataAccessConfigurationExtensions
{
    public static IServiceCollection ConfigureDataAccess(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<EfContext>(options => options
            .UseLazyLoadingProxies()
            .UseNpgsql(connectionString));

        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IInvitesRepository, InvitesRepository>();
        services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
        services.AddScoped<ITransactionsRepository, TransactionsRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();

        services.AddScoped<UnitOfWork>();

        return services;
    }
}