using Quixpenses.DatabaseAccess.DatabaseModels;

namespace Quixpenses.DatabaseAccess.Repositories.UsersSettings;

public interface IUsersSettingsRepository : IGenericRepository<UserSettings>
{
    Task<UserSettings> GetByIdAsync(Guid id);
}