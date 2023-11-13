using Quixpenses.App.Models;

namespace Quixpenses.App.DatabaseAccess.Repositories.UsersSettings;

public interface IUsersSettingsRepository : IGenericRepository<UserSettings>
{
    Task<UserSettings> GetByIdAsync(Guid id);
}