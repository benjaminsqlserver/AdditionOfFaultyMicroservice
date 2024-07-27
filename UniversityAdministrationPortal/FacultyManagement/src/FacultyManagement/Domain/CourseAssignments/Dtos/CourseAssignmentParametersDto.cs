namespace FacultyManagement.Domain.CourseAssignments.Dtos;

using FacultyManagement.Resources;

public sealed class CourseAssignmentParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
