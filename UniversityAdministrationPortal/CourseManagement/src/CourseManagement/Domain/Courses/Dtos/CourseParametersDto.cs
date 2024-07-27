namespace CourseManagement.Domain.Courses.Dtos;

using CourseManagement.Resources;

public sealed class CourseParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
