using Quixpenses.App.Models;

namespace Quixpenses.App.DatabaseAccess.Repositories.Transactions;

public class TransactionsRepository(
        EfContext context)
    : GenericRepository<Transaction>(context), ITransactionsRepository;