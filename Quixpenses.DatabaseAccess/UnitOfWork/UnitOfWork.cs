using Quixpenses.DatabaseAccess.Repositories.Currencies;
using Quixpenses.DatabaseAccess.Repositories.Invites;
using Quixpenses.DatabaseAccess.Repositories.Transactions;
using Quixpenses.DatabaseAccess.Repositories.Users;
using Quixpenses.DatabaseAccess.Repositories.UsersSettings;

namespace Quixpenses.DatabaseAccess.UnitOfWork;

public class UnitOfWork(
        EfContext context,
        IInvitesRepository invitesRepository,
        IUsersRepository usersRepository,
        IUsersSettingsRepository usersSettingsRepository,
        ICurrenciesRepository currenciesRepository,
        ITransactionsRepository transactionsRepository)
    : IUnitOfWork
{
    public IInvitesRepository InvitesRepository { get; } = invitesRepository;

    public IUsersRepository UsersRepository { get; } = usersRepository;

    public IUsersSettingsRepository UsersSettingsRepository { get; } = usersSettingsRepository;

    public ICurrenciesRepository CurrenciesRepository { get; } = currenciesRepository;

    public ITransactionsRepository TransactionsRepository { get; } = transactionsRepository;

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}