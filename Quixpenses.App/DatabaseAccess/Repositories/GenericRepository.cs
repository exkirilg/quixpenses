using Quixpenses.App.Models.Interfaces;

namespace Quixpenses.App.DatabaseAccess.Repositories;

public abstract class GenericRepository<T>(
        EfContext context)
    : IGenericRepository<T>
    where T : class, IDbModel
{
    protected readonly EfContext Context = context;

    public virtual async Task AddAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
    }
}