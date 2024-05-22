using Infrastructure.Entities.Interfaces;

namespace Infrastructure.Entities;

public class CourseCategoryEntity : ICourseCategoryEntity
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
}
