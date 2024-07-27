namespace CourseManagement.Domain.Instructors.Dtos;

using CourseManagement.Resources;

public sealed class InstructorParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
