using CourseProvider.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseProvider.Infrastructure.Data.Contexts;

public class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryEntity>().ToContainer("Categories")
            .HasPartitionKey(x => x.Id);

        modelBuilder.Entity<CourseEntity>().ToContainer("Courses")
            .HasPartitionKey(x => x.Id);

        modelBuilder.Entity<CourseEntity>().OwnsOne(x => x.Prices);
        modelBuilder.Entity<CourseEntity>().OwnsMany(x => x.Authors);
        modelBuilder.Entity<CourseEntity>().OwnsOne(x => x.Content, 
            content => content.OwnsMany(x => x.ProgramDetails));           
            
    }
}
