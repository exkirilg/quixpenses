using Quixpenses.App.TelegramUpdatesHandling.Handlers.NewExpense.Interfaces;
using Quixpenses.Common.Models;
using Quixpenses.Common.Models.DbModels;
using Quixpenses.DatabaseAccess.Interfaces;
using Quixpenses.Services.Expenses.Interfaces;

namespace Quixpenses.App.TelegramUpdatesHandling.Handlers.NewExpense;

public class NewExpenseQuickHandler(
    IUnitOfWork unitOfWork,
    ICreateExpenseService createExpenseService)
    : INewExpenseQuickHandler
{
    public async Task HandleAsync(User user, UpdateData update)
    {
        var currency = user.Settings!.Currency!;
        await createExpenseService.CreateExpenseAsync(user, update.Sum, currency);
        await unitOfWork.SaveChangesAsync();
    }
}