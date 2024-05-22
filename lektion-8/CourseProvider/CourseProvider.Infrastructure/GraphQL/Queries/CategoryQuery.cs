using CourseProvider.Infrastructure.Models;
using CourseProvider.Infrastructure.Services;

namespace CourseProvider.Infrastructure.GraphQL.Queries;

public class CategoryQuery(ICategoryService categoryService)
{
    private readonly ICategoryService _categoryService = categoryService;


    [GraphQLName("getCategories")]
    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        var result = await _categoryService.GetCategoriesAsync();
        return result.Result ?? null!;
    }

    [GraphQLName("getCategory")]
    public async Task<Category> GetCategoryAsync(string id)
    {
        var result = await _categoryService.GetCategoryAsync(id);
        return result.Result ?? null!;
    }
}
