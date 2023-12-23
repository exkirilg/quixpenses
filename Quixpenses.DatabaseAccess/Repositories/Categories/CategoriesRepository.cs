using Microsoft.EntityFrameworkCore;
using Quixpenses.Common.Models;

namespace Quixpenses.DatabaseAccess.Repositories.Categories;

public class CategoriesRepository(EfContext context) : GenericRepository<Category>(context), ICategoriesRepository
{
    public async Task<Category?> TryGetByIdAsync(Guid id)
    {
        return await Context.Categories.FindAsync(id);
    }

    public Task<Category?> TryGetByNameAsync(string name)
    {
        return Context.Categories.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
    }
}