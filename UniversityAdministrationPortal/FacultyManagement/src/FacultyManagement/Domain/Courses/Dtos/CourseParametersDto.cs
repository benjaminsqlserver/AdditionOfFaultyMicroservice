namespace FacultyManagement.Domain.Courses.Dtos;

using FacultyManagement.Resources;

public sealed class CourseParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
