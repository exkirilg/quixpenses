using Quixpenses.App.Models;

namespace Quixpenses.App.DatabaseAccess.Repositories.Transactions;

public class TransactionsRepository : GenericRepository<Transaction>, ITransactionsRepository
{
    public TransactionsRepository(EfContext context) : base(context)
    {
    }
}