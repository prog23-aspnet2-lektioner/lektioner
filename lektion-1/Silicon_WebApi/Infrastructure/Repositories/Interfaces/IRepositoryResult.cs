using System.Net;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryResult<T>
    {
        T? Entity { get; set; }
        Exception? Error { get; set; }
        HttpStatusCode StatusCode { get; set; }
    }
}