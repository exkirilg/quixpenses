using Quixpenses.Common.Models;
using Quixpenses.DatabaseAccess;
using Quixpenses.Services.Categories.Interfaces;

namespace Quixpenses.Services.Categories;

public class GetCategoryService(UnitOfWork unitOfWork) : IGetCategoryService
{
    public Task<Category?> TryGetCategoryAsync(string name)
    {
        return unitOfWork.CategoriesRepository.TryGetByNameAsync(name);
    }
}