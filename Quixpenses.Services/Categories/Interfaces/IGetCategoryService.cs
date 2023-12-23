using Quixpenses.Common.Models;

namespace Quixpenses.Services.Categories.Interfaces;

public interface IGetCategoryService
{
    Task<Category?> TryGetCategoryAsync(string name);
}