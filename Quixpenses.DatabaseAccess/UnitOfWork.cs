using Quixpenses.DatabaseAccess.Repositories.Categories;
using Quixpenses.DatabaseAccess.Repositories.Currencies;
using Quixpenses.DatabaseAccess.Repositories.Invites;
using Quixpenses.DatabaseAccess.Repositories.Transactions;
using Quixpenses.DatabaseAccess.Repositories.Users;

namespace Quixpenses.DatabaseAccess;

public class UnitOfWork(
    EfContext context,
    IInvitesRepository invitesRepository,
    IUsersRepository usersRepository,
    ICurrenciesRepository currenciesRepository,
    ITransactionsRepository transactionsRepository,
    ICategoriesRepository categoriesRepository)
{
    public IInvitesRepository InvitesRepository => invitesRepository;

    public IUsersRepository UsersRepository => usersRepository;

    public ICurrenciesRepository CurrenciesRepository => currenciesRepository;

    public ITransactionsRepository TransactionsRepository => transactionsRepository;

    public ICategoriesRepository CategoriesRepository => categoriesRepository;

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}