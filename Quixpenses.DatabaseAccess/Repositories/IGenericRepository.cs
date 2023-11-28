using Quixpenses.DatabaseAccess.DatabaseModels;
using Quixpenses.DatabaseAccess.DatabaseModels.Interfaces;

namespace Quixpenses.DatabaseAccess.Repositories;

public interface IGenericRepository<T> where T : class, IDbModel
{
    Task AddAsync(T entity);
}