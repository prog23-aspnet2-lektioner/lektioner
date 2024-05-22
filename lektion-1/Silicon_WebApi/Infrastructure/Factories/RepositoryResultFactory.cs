using Infrastructure.Repositories;

namespace Infrastructure.Factories;

public class RepositoryResultFactory<T>
{
    public static RepositoryResult<T> Created(T entity)
    {
        return new RepositoryResult<T>
        {
            StatusCode = System.Net.HttpStatusCode.Created,
            Entity = entity
        };
    }

    public static RepositoryResult<T> Ok()
    {
        return new RepositoryResult<T>
        {
            StatusCode = System.Net.HttpStatusCode.OK,
        };
    }

    public static RepositoryResult<T> Ok(T entity)
    {
        return new RepositoryResult<T> 
        { 
            StatusCode = System.Net.HttpStatusCode.OK,
            Entity = entity 
        };
    }

    public static RepositoryResult<T> NotFound()
    {
        return new RepositoryResult<T>
        {
            StatusCode = System.Net.HttpStatusCode.NotFound
        };
    }

    public static RepositoryResult<T> Found()
    {
        return new RepositoryResult<T>
        {
            StatusCode = System.Net.HttpStatusCode.Found
        };
    }

    public static RepositoryResult<T> Error(Exception error)
    {
        return new RepositoryResult<T>
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Error = error
        };
    }
}
