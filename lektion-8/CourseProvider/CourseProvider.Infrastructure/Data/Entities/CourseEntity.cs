using System.ComponentModel.DataAnnotations;

namespace CourseProvider.Infrastructure.Data.Entities;

public class CourseEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? ImageUri { get; set; }
    public string? ImageHeaderUri { get; set; }
    public bool IsBestseller { get; set; }
    public bool IsDigital { get; set; }
    public string[]? Categories { get; set; }
    public string? Title { get; set; }
    public string? Ingress { get; set; }
    public decimal StarRating { get; set; }
    public string? Reviews { get; set; }
    public string? LikesInProcent { get; set; }
    public string? Likes { get; set; }
    public string? Hours { get; set; }
    public List<AuthorEntity>? Authors { get; set; }
    public PriceEntity? Prices { get; set; }
    public ContentEntity? Content { get; set; }
}

public class PriceEntity
{
    public string? Currency { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}

public class ContentEntity
{
    public string? Description { get; set; }
    public string[]? Includes { get; set; }
    public List<ProgramDetailEntity>? ProgramDetails { get; set; }
}

public class ProgramDetailEntity
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}

public class AuthorEntity
{
    public string? Name { get; set; }
    public string? ImageUri { get; set; }
}
