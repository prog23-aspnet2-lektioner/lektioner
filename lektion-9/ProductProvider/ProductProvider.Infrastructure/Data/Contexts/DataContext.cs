using Microsoft.EntityFrameworkCore;
using ProductProvider.Infrastructure.Data.Entities;

namespace ProductProvider.Infrastructure.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<ProductEntity> Products { get; set; }
}
