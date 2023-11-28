using Microsoft.EntityFrameworkCore;
using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.DatabaseAccess.Repositories.UsersSettings;

public class UsersSettingsRepository(
        EfContext context)
    : GenericRepository<UserSettings>(context), IUsersSettingsRepository
{
    public async Task<UserSettings> GetByIdAsync(Guid id)
    {
        var result = await Context.UsersSettings.SingleAsync(x => x.Id == id);
        return result;
    }
}