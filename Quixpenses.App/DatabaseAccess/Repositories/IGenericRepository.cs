using Quixpenses.App.DatabaseAccess.DatabaseModels;

namespace Quixpenses.App.DatabaseAccess.Repositories;

public interface IGenericRepository<T> where T : class, IDbModel
{
    Task AddAsync(T entity);
}