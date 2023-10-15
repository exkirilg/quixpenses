namespace Quixpenses.App.DatabaseAccess.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task AddAsync(T entity);
}