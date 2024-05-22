using Infrastructure.Services;

namespace Infrastructure.Factories;

public class ServiceResultFactory<T>
{
    public static ServiceResult<T> Created(T model)
    {
        return new ServiceResult<T>
        {
            StatusCode = System.Net.HttpStatusCode.Created,
            Model = model
        };
    }

    public static ServiceResult<T> Ok()
    {
        return new ServiceResult<T>
        {
            StatusCode = System.Net.HttpStatusCode.OK,
        };
    }

    public static ServiceResult<T> Ok(T model)
    {
        return new ServiceResult<T>
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Model = model
        };
    }

    public static ServiceResult<T> NotFound()
    {
        return new ServiceResult<T>
        {
            StatusCode = System.Net.HttpStatusCode.NotFound
        };
    }

    public static ServiceResult<T> Found()
    {
        return new ServiceResult<T>
        {
            StatusCode = System.Net.HttpStatusCode.Found
        };
    }

    public static ServiceResult<T> Error(Exception error)
    {
        return new ServiceResult<T>
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Error = error
        };
    }
}
