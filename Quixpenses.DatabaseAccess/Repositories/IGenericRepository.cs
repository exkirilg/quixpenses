using Quixpenses.Common.Models.Interfaces;

namespace Quixpenses.DatabaseAccess.Repositories;

public interface IGenericRepository<T> where T : class, IDbModel
{
    Task AddAsync(T entity);
}