using Quixpenses.Common.Models.Commands.Interfaces;
using Quixpenses.Common.Models.DbModels;
using Quixpenses.DatabaseAccess.Interfaces;
using Quixpenses.Services.Users.Interfaces;

namespace Quixpenses.Services.Users;

public class UserSessionService(IUnitOfWork unitOfWork) : IUserSessionService
{
    public void ResetSession(User user, Session session)
    {
        if (user.CurrentSession is not null)
        {
            unitOfWork.Context.Remove(user.CurrentSession);
        }

        user.CurrentSession = session;
    }

    public void UpdateSession(Session session, ICommand command)
    {
        var isModified = false;

        if (command.Equals(session.Command) is false)
        {
            isModified = true;
            session.Command = command;
        }

        if (isModified is false)
        {
            return;
        }

        unitOfWork.Context.Update(session);
    }
}