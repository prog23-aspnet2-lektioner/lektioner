using System.Net;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services;

public class ServiceResult<T> : IServiceResult<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public T? Model { get; set; }
    public Exception? Error { get; set; }
}