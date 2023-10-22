using Microsoft.EntityFrameworkCore;
using Quixpenses.App.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.DatabaseAccess.Repositories.Users;

public class UsersRepository : IUsersRepository
{
    private readonly EfContext _context;

    public UsersRepository(EfContext context)
    {
        _context = context;
    }

    public async Task<DbUser?> TryGetByIdAsync(long id)
    {
        var result = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task<DbUser?> TryGetByIdReadonlyAsync(long id)
    {
        var result = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }

    public async Task AddAsync(DbUser entity)
    {
        await _context.Users.AddAsync(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}