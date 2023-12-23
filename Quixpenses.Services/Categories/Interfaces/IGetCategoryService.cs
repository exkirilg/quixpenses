using Quixpenses.Common.Models.DbModels;

namespace Quixpenses.Services.Categories.Interfaces;

public interface IGetCategoryService
{
    Task<Category?> TryGetCategoryAsync(string name);
}