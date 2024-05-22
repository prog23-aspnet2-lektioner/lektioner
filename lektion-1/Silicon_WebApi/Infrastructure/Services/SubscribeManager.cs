using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using System.Diagnostics;

namespace Infrastructure.Services;

public class SubscribeManager(ISubscribeRepository subscribeRepository) : ISubscribeManager
{
    private readonly ISubscribeRepository _subscribeRepository = subscribeRepository;

    public async Task<IServiceResult<bool>> SubscribeAsync(SubscribeModel model)
    {
        try
        {
            var result = await _subscribeRepository.CreateAsync(SubscribeFactory.Create(model));
            if (result.StatusCode == System.Net.HttpStatusCode.Created)
                return ServiceResultFactory<bool>.Created(true);

            return ServiceResultFactory<bool>.Error(new Exception("Something went wrong."));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ServiceResultFactory<bool>.Error(ex);
        }
    }

    public async Task<IServiceResult<bool>> UnsubscribeAsync(string email)
    {
        try
        {
            var result = await _subscribeRepository.DeleteAsync(x => x.Email == email);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return ServiceResultFactory<bool>.Ok();

            return ServiceResultFactory<bool>.Error(new Exception("Subscriber was not deleted"));

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ServiceResultFactory<bool>.Error(ex);
        }

    }

    public async Task<IServiceResult<bool>> SubscriberExistsAsync(string email)
    {
        var result = await _subscribeRepository.ExistsAsync(x => x.Email == email);
        if (result.StatusCode == System.Net.HttpStatusCode.Found)
            return ServiceResultFactory<bool>.Found();

        return ServiceResultFactory<bool>.NotFound();

    }

    public async Task<IServiceResult<bool>> UpdateSubscriberAsync(SubscribeModel model)
    {
        try
        {
            var result = await _subscribeRepository.UpdateAsync(x => x.Email == model.Email, SubscribeFactory.Create(model));
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return ServiceResultFactory<bool>.Ok();

            return ServiceResultFactory<bool>.NotFound();

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ServiceResultFactory<bool>.Error(ex);
        }
    }
}
