using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.DatabaseAccess.Repositories.Expenses;

public class ExpensesRepository(EfContext context) : GenericRepository<Expense>(context), IExpensesRepository;