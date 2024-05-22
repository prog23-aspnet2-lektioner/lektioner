using CourseProvider.Infrastructure.GraphQL.Mutations;
using CourseProvider.Infrastructure.GraphQL.ObjectTypes;
using CourseProvider.Infrastructure.GraphQL.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CourseProvider.Infrastructure.GraphQL;

public static class GraphQLConfiguration
{
    public static void AddGraphQLServiceConfiguration(this IServiceCollection services)
    {
        services.AddGraphQLFunction()
            .AddQueryType<CourseQuery>()
            .AddType<CourseType>()
            .AddMutationType<CourseMutation>();
            
    }
}
