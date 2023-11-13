using Quixpenses.App.DatabaseAccess.Repositories.Currencies;
using Quixpenses.App.DatabaseAccess.Repositories.Invites;
using Quixpenses.App.DatabaseAccess.Repositories.Transactions;
using Quixpenses.App.DatabaseAccess.Repositories.Users;
using Quixpenses.App.DatabaseAccess.Repositories.UsersSettings;

namespace Quixpenses.App.DatabaseAccess.UnitOfWork;

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