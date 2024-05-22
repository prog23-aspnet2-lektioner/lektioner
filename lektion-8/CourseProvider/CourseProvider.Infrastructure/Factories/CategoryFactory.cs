using CourseProvider.Infrastructure.Data.Entities;
using CourseProvider.Infrastructure.Models;

namespace CourseProvider.Infrastructure.Factories;

public static class CategoryFactory
{
    public static CategoryEntity Create(CategoryRequest request)
    {
        return new CategoryEntity
        {
            CategoryName = request.CategoryName
        };
    }

    public static Category Create(CategoryEntity entity)
    {
        return new Category
        {
            Id = entity.Id,
            CategoryName = entity.CategoryName
        };
    }
}
