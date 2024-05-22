using CourseProvider.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseProvider.Infrastructure.Data;

public static class DataConfiguration
{
    public static void AddDataServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPooledDbContextFactory<DataContext>(x => x.UseCosmos(Environment.GetEnvironmentVariable("COSMOS_URI")!, Environment.GetEnvironmentVariable("COSMOS_DBNAME")!)
                .UseLazyLoadingProxies()
        );

        var sp = services.BuildServiceProvider();
        using var scope = sp.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DataContext>>();
        using var context = contextFactory.CreateDbContext();

        context.Database.EnsureCreated();
    }
}
