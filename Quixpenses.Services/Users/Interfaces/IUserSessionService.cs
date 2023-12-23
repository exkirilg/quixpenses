using Quixpenses.Common.Models.Commands.Interfaces;
using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.Services.Users.Interfaces;

public interface IUserSessionService
{
    void ResetSession(User user, Session session);

    void UpdateSession(Session session, ICommand command);
}