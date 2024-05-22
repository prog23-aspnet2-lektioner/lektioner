using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;

namespace Presentation.WebApi.Configurations;

public static class RepositoryConfiguration
{
    public static void RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISubscribeRepository, SubscribeRepository>();
        services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
    }
}
