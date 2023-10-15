using Microsoft.EntityFrameworkCore;

namespace Quixpenses.App.DatabaseAccess.Repositories;

public abstract class AbstractRepository<T> : IGenericRepository<T>
    where T : class
{
    protected readonly DbSet<T> DbSet;

    protected AbstractRepository(DbSet<T> dbSet)
    {
        DbSet = dbSet;
    }

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }
}