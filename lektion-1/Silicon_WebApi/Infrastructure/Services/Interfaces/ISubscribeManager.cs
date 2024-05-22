using Infrastructure.Models;

namespace Infrastructure.Services.Interfaces
{
    public interface ISubscribeManager
    {
        Task<IServiceResult<bool>> SubscribeAsync(SubscribeModel model);
        Task<IServiceResult<bool>> SubscriberExistsAsync(string email);
        Task<IServiceResult<bool>> UnsubscribeAsync(string email);
        Task<IServiceResult<bool>> UpdateSubscriberAsync(SubscribeModel model);
    }
}