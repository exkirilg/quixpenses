using Quixpenses.App.DatabaseAccess.Repositories.Currencies;
using Quixpenses.App.DatabaseAccess.Repositories.Invites;
using Quixpenses.App.DatabaseAccess.Repositories.Transactions;
using Quixpenses.App.DatabaseAccess.Repositories.Users;
using Quixpenses.App.DatabaseAccess.Repositories.UsersSettings;

namespace Quixpenses.App.DatabaseAccess.UnitOfWork;

public interface IUnitOfWork
{
    IInvitesRepository InvitesRepository { get; }

    IUsersRepository UsersRepository { get; }

    IUsersSettingsRepository UsersSettingsRepository { get; }

    ICurrenciesRepository CurrenciesRepository { get; }

    ITransactionsRepository TransactionsRepository { get; }

    Task SaveChangesAsync();
}