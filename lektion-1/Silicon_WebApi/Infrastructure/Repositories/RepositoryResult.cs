using System.Net;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories;

public class RepositoryResult<T> : IRepositoryResult<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public T? Entity { get; set; }
    public Exception? Error { get; set; }
}
