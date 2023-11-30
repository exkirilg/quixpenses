namespace Quixpenses.Services.Actions;

// public class CreateTransactionAction(ICreateTransactionDbAccess dbAccess)
//     : ActionErrors, IAsyncAction<CreateTransactionRequestDto, Transaction?>
// {
//     public async Task<Transaction?> ActionAsync(CreateTransactionRequestDto request)
//     {
//         var user = await dbAccess.TryGetUserAsync(request.Message.ChatId);
//
//         if (user is null || !user.IsAuthorized)
//         {
//             AddError("Unauthorized");
//         }
//
//         var (sum, currencyCode) = request.Message.ParseTransaction();
//
//         var currency = await dbAccess.TryGetCurrencyAsync(currencyCode);
//
//         if (currency is null)
//         {
//             AddError("Currency not found");
//         }
//
//         var transaction = new Transaction
//         {
//             UserId = user!.Id,
//             CurrencyId = currency!.Id,
//             Sum = (int)(Math.Round(sum, currency.FractionDigits) * Math.Pow(10, currency.FractionDigits)),
//         };
//
//         if (!HasErrors)
//         {
//             await dbAccess.AddAsync(transaction);
//         }
//
//         return HasErrors ? null : transaction;
//     }
// }