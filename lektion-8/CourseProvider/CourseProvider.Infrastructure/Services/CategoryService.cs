using CourseProvider.Infrastructure.Data.Contexts;
using CourseProvider.Infrastructure.Data.Entities;
using CourseProvider.Infrastructure.Factories;
using CourseProvider.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CourseProvider.Infrastructure.Services;

public interface ICategoryService
{
    Task<ResponseResult<Category>> CreateCategoryAsync(CategoryRequest request);
    Task<ResponseResult<Category>> GetCategoryAsync(string id);
    Task<ResponseResult<IEnumerable<Category>>> GetCategoriesAsync();
    Task<ResponseResult<Category>> UpdateCategoryAsync(string id, CategoryRequest request);
    Task<ResponseResult<Category>> DeleteCategoryAsync(string id);
}



public class CategoryService(IDbContextFactory<DataContext> contextFactory) : ICategoryService
{
    private readonly IDbContextFactory<DataContext> _contextFactory = contextFactory;

    public async Task<ResponseResult<Category>> CreateCategoryAsync(CategoryRequest request)
    {
        var response = new ResponseResult<Category>();

        try
        {
            if (string.IsNullOrEmpty(request.CategoryName))
            {
                response.Error = "Category name is required";
            }
            else
            {
                await using var context = _contextFactory.CreateDbContext();

                if (await context.Categories.AnyAsync(c => c.CategoryName == request.CategoryName))
                {
                    response.Error = "Category name already exists";
                }
                else
                {
                    var entity = CategoryFactory.Create(request);
                    context.Categories.Add(entity);
                    await context.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Result = CategoryFactory.Create(entity);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            response.IsSuccess = false;
            response.Error = ex.Message;
        }

        return response;
    }

    public async Task<ResponseResult<Category>> DeleteCategoryAsync(string id)
    {
        var response = new ResponseResult<Category>();

        try
        {
            using var context = _contextFactory.CreateDbContext();
            var entity = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (entity != null)
            {
                context.Categories.Remove(entity);
                await context.SaveChangesAsync();

                response.IsSuccess = true;
            }
            else
            {
                response.Error = "Category not found";
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            response.IsSuccess = false;
            response.Error = ex.Message;
        }

        return response;
    }

    public async Task<ResponseResult<IEnumerable<Category>>> GetCategoriesAsync()
    {
        var response = new ResponseResult<IEnumerable<Category>>();

        try
        {
            using var context = _contextFactory.CreateDbContext();
            var entities = context.Categories.ToList();

            response.IsSuccess = true;
            response.Result = entities.Select(CategoryFactory.Create);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            response.IsSuccess = false;
            response.Error = ex.Message;
        }

        return response;
    }

    public async Task<ResponseResult<Category>> GetCategoryAsync(string id)
    {
        var response = new ResponseResult<Category>();

        try
        {
            using var context = _contextFactory.CreateDbContext();
            var entity = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (entity != null)
            {
                response.IsSuccess = true;
                response.Result = CategoryFactory.Create(entity);
            }
            else
            {
                response.Error = "Category not found";
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            response.IsSuccess = false;
            response.Error = ex.Message;
        }

        return response;
    }

    public async Task<ResponseResult<Category>> UpdateCategoryAsync(string id, CategoryRequest request)
    {
        var response = new ResponseResult<Category>();

        try
        {
            using var context = _contextFactory.CreateDbContext();
            var entity = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (entity != null)
            {
                var updatedEntity = CategoryFactory.Create(request);
                context.Entry(entity).CurrentValues.SetValues(updatedEntity);
                await context.SaveChangesAsync();

                response.IsSuccess = true;
                response.Result = CategoryFactory.Create(entity);
            }
            else
            {
                response.Error = "Category not found";
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            response.IsSuccess = false;
            response.Error = ex.Message;
        }

        return response;
    }
}
