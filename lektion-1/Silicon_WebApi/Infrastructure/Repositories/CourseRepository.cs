using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class CourseRepository(ApiContext context) : Repo<CourseEntity>(context), ICourseRepository
{
    private readonly ApiContext _context = context;

    public async Task<IRepositoryResult<CourseEntity>> GetWithCategoryAsync(Expression<Func<CourseEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Courses
                .Include(i => i.CourseCategory)
                .FirstOrDefaultAsync(expression);

            if (entity != null)
                return RepositoryResultFactory<CourseEntity>.Ok(entity);

            return RepositoryResultFactory<CourseEntity>.NotFound();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return RepositoryResultFactory<CourseEntity>.Error(ex);
        }
    }


    public virtual async Task<IRepositoryResult<IEnumerable<CourseEntity>>> GetWithCategoryAsync()
    {
        try
        {
            var entities = await _context.Courses
                .Include(i => i.CourseCategory)
                .ToListAsync();

            return RepositoryResultFactory<IEnumerable<CourseEntity>>.Ok(entities);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return RepositoryResultFactory<IEnumerable<CourseEntity>>.Error(ex);
        }

    }

}
