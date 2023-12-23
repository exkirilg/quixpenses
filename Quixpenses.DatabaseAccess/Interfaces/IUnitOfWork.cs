using Quixpenses.DatabaseAccess.Repositories.Categories;
using Quixpenses.DatabaseAccess.Repositories.Currencies;
using Quixpenses.DatabaseAccess.Repositories.Expenses;
using Quixpenses.DatabaseAccess.Repositories.Invites;
using Quixpenses.DatabaseAccess.Repositories.Users;

namespace Quixpenses.DatabaseAccess.Interfaces;

public interface IUnitOfWork
{
    EfContext Context { get; }

    IInvitesRepository InvitesRepository { get; }

    IUsersRepository UsersRepository { get; }

    ICurrenciesRepository CurrenciesRepository { get; }

    IExpensesRepository ExpensesRepository { get; }

    ICategoriesRepository CategoriesRepository { get; }

    Task SaveChangesAsync();
}