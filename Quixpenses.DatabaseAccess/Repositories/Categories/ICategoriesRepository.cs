using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.DatabaseAccess.Repositories.Categories;

public interface ICategoriesRepository : IGenericRepository<Category>
{
    Task<Category?> TryGetByIdAsync(Guid id);

    Task<Category?> TryGetByNameAsync(string name);
}