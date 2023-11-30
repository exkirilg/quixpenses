using Quixpenses.Common.Models;

namespace Quixpenses.DatabaseAccess.Repositories.Transactions;

public class TransactionsRepository(EfContext context) : GenericRepository<Transaction>(context), ITransactionsRepository;