using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProductProvider.Infrastructure.Data.Contexts;
using ProductProvider.Infrastructure.Data.Entities;

namespace ProductProvider.Functions;

public class Create(IDbContextFactory<DataContext> contextFactory)
{ 
    private readonly IDbContextFactory<DataContext> _contextFactory = contextFactory;

    [Function("Create")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
    {
        var body = await new StreamReader(req.Body).ReadToEndAsync();
        var productEntity = JsonConvert.DeserializeObject<ProductEntity>(body);

        if (productEntity != null )
        {
            using var context = _contextFactory.CreateDbContext();

            context.Add(productEntity);
            await context.SaveChangesAsync();

            return new OkObjectResult(productEntity);
        }

        return new BadRequestObjectResult(new { Error = "invalid modelstate" });
    }
}
