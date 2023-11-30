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
    ITransactionsRepository transactionsRepository)
{
    public IInvitesRepository InvitesRepository { get; } = invitesRepository;

    public IUsersRepository UsersRepository { get; } = usersRepository;

    public ICurrenciesRepository CurrenciesRepository { get; } = currenciesRepository;

    public ITransactionsRepository TransactionsRepository { get; } = transactionsRepository;

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}