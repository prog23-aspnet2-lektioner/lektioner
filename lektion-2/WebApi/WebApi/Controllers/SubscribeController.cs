using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;


    #region CREATE

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribeModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (!await _context.Subscribers.AnyAsync(x => x.Email == model.Email))
                {
                    _context.Add(SubscribeFactory.Create(model));
                    await _context.SaveChangesAsync();
                    return Ok();
                }

                return Conflict();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        return BadRequest();
    }

    #endregion

    #region UPDATE

    [HttpPut]
    public async Task<IActionResult> Update(SubscribeModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var entity = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == model.Email);
                if (entity != null)
                {
                    entity = SubscribeFactory.Update(entity, model);
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        return BadRequest();
    }

    #endregion

    #region DELETE

    [HttpDelete]
    public async Task<IActionResult> Subscribe(string email)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var entity = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
                if (entity != null)
                {
                    _context.Remove(entity);
                    await _context.SaveChangesAsync();
                    return Ok();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        return BadRequest();
    }

    #endregion

}
