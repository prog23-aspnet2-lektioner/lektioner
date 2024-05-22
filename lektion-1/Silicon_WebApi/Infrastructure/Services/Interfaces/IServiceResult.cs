using System.Net;

namespace Infrastructure.Services.Interfaces
{
    public interface IServiceResult<T>
    {
        Exception? Error { get; set; }
        T? Model { get; set; }
        HttpStatusCode StatusCode { get; set; }
    }
}