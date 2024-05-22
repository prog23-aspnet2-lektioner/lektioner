using Infrastructure.Models;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribersController(ISubscribeManager subscribeManager) : ControllerBase
{
    private readonly ISubscribeManager _subscribeManager = subscribeManager;

    #region Subscribe 
    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribeModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var result = await _subscribeManager.SubscriberExistsAsync(model.Email);

                if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return Ok(await _subscribeManager.SubscribeAsync(model));

                return Conflict("Already subscribed");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Problem();
        }

        return BadRequest();
    }
    #endregion


    #region Unsubscribe 
    [HttpDelete]
    public async Task<IActionResult> Unsubscribe(string email)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var result = await _subscribeManager.UnsubscribeAsync(email);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    return Ok();

                return NotFound();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Problem();
        }

        return BadRequest();
    }
    #endregion

    #region Update Subscriber 
    [HttpPut]
    public async Task<IActionResult> Update(SubscribeModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var result = await _subscribeManager.UpdateSubscriberAsync(model);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    return Ok();

                return NotFound();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Problem();
        }

        return BadRequest();
    }
    #endregion


}
