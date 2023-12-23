using Quixpenses.Common.Models.DbModels;
using Quixpenses.DatabaseAccess.Interfaces;
using Quixpenses.Services.Expenses.Interfaces;

namespace Quixpenses.Services.Expenses;

public class CreateExpenseService(IUnitOfWork unitOfWork) : ICreateExpenseService
{
    public async Task<Expense> CreateExpenseAsync(
        User user,
        float sum,
        Currency currency,
        Category? category = null)
    {
        var result = new Expense
        {
            User = user,
            Currency = currency,
            Category = category,
            Sum = (int)(Math.Round(sum, currency.FractionDigits) * Math.Pow(10, currency.FractionDigits)),
        };

        await unitOfWork.ExpensesRepository.AddAsync(result);

        return result;
    }
}