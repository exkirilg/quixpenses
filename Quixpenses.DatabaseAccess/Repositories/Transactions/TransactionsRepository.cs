using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.DatabaseAccess.Repositories.Transactions;

public class TransactionsRepository(
        EfContext context)
    : GenericRepository<Transaction>(context), ITransactionsRepository;