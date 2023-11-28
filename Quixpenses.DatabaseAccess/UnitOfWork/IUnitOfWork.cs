using Quixpenses.DatabaseAccess.Repositories.Currencies;
using Quixpenses.DatabaseAccess.Repositories.Invites;
using Quixpenses.DatabaseAccess.Repositories.Transactions;
using Quixpenses.DatabaseAccess.Repositories.Users;
using Quixpenses.DatabaseAccess.Repositories.UsersSettings;

namespace Quixpenses.DatabaseAccess.UnitOfWork;

public interface IUnitOfWork
{
    IInvitesRepository InvitesRepository { get; }

    IUsersRepository UsersRepository { get; }

    IUsersSettingsRepository UsersSettingsRepository { get; }

    ICurrenciesRepository CurrenciesRepository { get; }

    ITransactionsRepository TransactionsRepository { get; }

    Task SaveChangesAsync();
}