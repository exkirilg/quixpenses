using Microsoft.Extensions.DependencyInjection;
using Quixpenses.Services.Categories;
using Quixpenses.Services.Categories.Interfaces;
using Quixpenses.Services.Currencies;
using Quixpenses.Services.Currencies.Interfaces;
using Quixpenses.Services.Expenses;
using Quixpenses.Services.Expenses.Interfaces;
using Quixpenses.Services.Invites;
using Quixpenses.Services.Invites.Interfaces;
using Quixpenses.Services.Users;
using Quixpenses.Services.Users.Interfaces;

namespace Quixpenses.Services.DiConfiguration;

public static class ServicesConfigurationExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services
            .ConfigureUsersServices()
            .ConfigureInvitesServices()
            .ConfigureCurrenciesServices()
            .ConfigureCategoriesServices()
            .ConfigureExpensesServices();
        return services;
    }

    private static IServiceCollection ConfigureUsersServices(this IServiceCollection services)
    {
        services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
        services.AddScoped<IUserCreationService, UserCreationService>();
        services.AddScoped<IUserSettingsService, UserSettingsService>();
        services.AddScoped<IUserSessionService, UserSessionService>();
        return services;
    }

    private static IServiceCollection ConfigureInvitesServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateInviteService, CreateInviteService>();
        services.AddScoped<IUseInviteService, UseInviteService>();
        return services;
    }

    private static IServiceCollection ConfigureCurrenciesServices(this IServiceCollection services)
    {
        services.AddScoped<IGetCurrencyService, GetCurrencyService>();
        return services;
    }

    private static IServiceCollection ConfigureExpensesServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateExpenseService, CreateExpenseService>();
        return services;
    }

    private static IServiceCollection ConfigureCategoriesServices(this IServiceCollection services)
    {
        services.AddScoped<IGetCategoryService, GetCategoryService>();
        return services;
    }
}