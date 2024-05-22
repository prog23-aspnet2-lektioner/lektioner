namespace CourseProvider.Infrastructure.Models;

public class ResponseResult<T>
{
    public bool IsSuccess { get; set; }
    public string? Error { get; set; }
    public T? Result { get; set; }
}
