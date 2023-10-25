using Quixpenses.App.DatabaseAccess.Repositories.Currencies;
using Quixpenses.App.DatabaseAccess.Repositories.Invites;
using Quixpenses.App.DatabaseAccess.Repositories.Transactions;
using Quixpenses.App.DatabaseAccess.Repositories.Users;

namespace Quixpenses.App.DatabaseAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly EfContext _context;

    public UnitOfWork(
        EfContext context,
        IInvitesRepository invitesRepository,
        IUsersRepository usersRepository,
        ICurrenciesRepository currenciesRepository,
        ITransactionsRepository transactionsRepository)
    {
        _context = context;
        InvitesRepository = invitesRepository;
        UsersRepository = usersRepository;
        CurrenciesRepository = currenciesRepository;
        TransactionsRepository = transactionsRepository;
    }

    public IInvitesRepository InvitesRepository { get; }

    public IUsersRepository UsersRepository { get; }

    public ICurrenciesRepository CurrenciesRepository { get; }

    public ITransactionsRepository TransactionsRepository { get; }

    public async Task SaveChangesAsync()
    {
        await this._context.SaveChangesAsync();
    }
}