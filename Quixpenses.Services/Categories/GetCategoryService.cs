using Quixpenses.Common.Models.DbModels;
using Quixpenses.DatabaseAccess.Interfaces;
using Quixpenses.Services.Categories.Interfaces;

namespace Quixpenses.Services.Categories;

public class GetCategoryService(IUnitOfWork unitOfWork) : IGetCategoryService
{
    public Task<Category?> TryGetCategoryAsync(string name)
    {
        return unitOfWork.CategoriesRepository.TryGetByNameAsync(name);
    }
}