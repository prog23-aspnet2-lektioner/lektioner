using Infrastructure.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.Interfaces;

public interface ICourseRepository : IRepo<CourseEntity>
{
    Task<IRepositoryResult<IEnumerable<CourseEntity>>> GetWithCategoryAsync();
    Task<IRepositoryResult<CourseEntity>> GetWithCategoryAsync(Expression<Func<CourseEntity, bool>> expression);
}
