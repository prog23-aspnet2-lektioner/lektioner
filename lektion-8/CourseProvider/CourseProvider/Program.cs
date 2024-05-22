using CourseProvider.Infrastructure.Data;
using CourseProvider.Infrastructure.Data.Repositories;
using CourseProvider.Infrastructure.GraphQL;
using CourseProvider.Infrastructure.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((context, services) =>
    {

        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddDataServiceConfiguration(context.Configuration);
        services.AddRepositoryConfiguration(context.Configuration);
        services.AddServiceConfiguration(context.Configuration);
        services.AddGraphQLServiceConfiguration();

    })
    .Build();



host.Run();
