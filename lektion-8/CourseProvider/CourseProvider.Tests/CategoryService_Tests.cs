
using CourseProvider.Infrastructure.Data.Contexts;
using CourseProvider.Infrastructure.Data.Entities;
using CourseProvider.Infrastructure.Models;
using CourseProvider.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CourseProvider.Tests;

public class CategoryService_Tests
{
    private readonly IDbContextFactory<DataContext> _contextFactory;
    private readonly ICategoryService _categoryService;

    public CategoryService_Tests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _contextFactory = new InMemoryContextFactory(options);
        _categoryService = new CategoryService(_contextFactory);
    }

    [Fact]
    public async Task CreateCategoryAsync_ShouldReturnSuccessResult_WhenCategoryIsCreated()
    {
        // Arrange
        var request = new CategoryRequest { CategoryName = "Test Category" };

        // Act
        var result = await _categoryService.CreateCategoryAsync(request);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Result);
        Assert.Equal(request.CategoryName, result.Result.CategoryName);

        // Verify category is added to the database
        await using var context = _contextFactory.CreateDbContext();
        var categoryInDb = await context.Categories.FirstOrDefaultAsync(c => c.Id == result.Result.Id);
        Assert.NotNull(categoryInDb);
    }

    [Fact]
    public async Task CreateCategoryAsync_ShouldReturnErrorResult_WhenRequestisEmpty()
    {
        // Arrange
        var request = new CategoryRequest();

        // Act
        var result = await _categoryService.CreateCategoryAsync(request);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Error);
        Assert.Equal("Category name is required", result.Error);
    }
}

public class InMemoryContextFactory : IDbContextFactory<DataContext>
{
    private readonly DbContextOptions<DataContext> _options;

    public InMemoryContextFactory(DbContextOptions<DataContext> options)
    {
        _options = options;
    }

    public DataContext CreateDbContext()
    {
        return new DataContext(_options);
    }
}