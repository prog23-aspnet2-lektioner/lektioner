using Infrastructure.Services;
using Infrastructure.Services.Interfaces;

namespace Presentation.WebApi.Configurations;

public static class ServiceConfiguration
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISubscribeManager, SubscribeManager>();
    }
}
