namespace CourseManagement.Domain.Enrollments.Dtos;

using CourseManagement.Resources;

public sealed class EnrollmentParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
