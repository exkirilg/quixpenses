using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.Services.Expenses.Interfaces;

public interface ICreateExpenseService
{
    Task<Expense> CreateExpenseAsync(
        User user,
        float sum,
        Currency currency,
        Category? category = null);
}