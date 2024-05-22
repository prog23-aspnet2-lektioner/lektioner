using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductProvider.Infrastructure.Data.Contexts;

namespace ProductProvider.Functions;

public class GetAll(IDbContextFactory<DataContext> dbContextFactory)
{
    private readonly IDbContextFactory<DataContext> _dbContextFactory = dbContextFactory;

    [Function("GetAll")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        var context = _dbContextFactory.CreateDbContext();
        var items = await context.Products.OrderBy(o => o.Title).ToListAsync();

        return new OkObjectResult(items);
    }
}
