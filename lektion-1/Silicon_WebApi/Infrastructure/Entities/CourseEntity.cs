using Infrastructure.Entities.Interfaces;

namespace Infrastructure.Entities;

public class CourseEntity : ICourseEntity
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Price { get; set; } = null!;

    public int CourseCategoryId { get; set; }
    public CourseCategoryEntity CourseCategory { get; set; } = null!;
}
