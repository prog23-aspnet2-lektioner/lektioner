namespace Infrastructure.Entities.Interfaces
{
    public interface ICourseEntity
    {
        CourseCategoryEntity CourseCategory { get; set; }
        int CourseCategoryId { get; set; }
        string Id { get; set; }
        string Price { get; set; }
        string Title { get; set; }
    }
}