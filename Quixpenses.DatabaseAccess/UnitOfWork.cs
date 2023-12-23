using Quixpenses.DatabaseAccess.Interfaces;
using Quixpenses.DatabaseAccess.Repositories.Categories;
using Quixpenses.DatabaseAccess.Repositories.Currencies;
using Quixpenses.DatabaseAccess.Repositories.Expenses;
using Quixpenses.DatabaseAccess.Repositories.Invites;
using Quixpenses.DatabaseAccess.Repositories.Users;

namespace Quixpenses.DatabaseAccess;

public class UnitOfWork(
    EfContext context,
    IInvitesRepository invitesRepository,
    IUsersRepository usersRepository,
    ICurrenciesRepository currenciesRepository,
    IExpensesRepository expensesRepository,
    ICategoriesRepository categoriesRepository)
    : IUnitOfWork
{
    public EfContext Context => context;

    public IInvitesRepository InvitesRepository => invitesRepository;

    public IUsersRepository UsersRepository => usersRepository;

    public ICurrenciesRepository CurrenciesRepository => currenciesRepository;

    public IExpensesRepository ExpensesRepository => expensesRepository;

    public ICategoriesRepository CategoriesRepository => categoriesRepository;

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}