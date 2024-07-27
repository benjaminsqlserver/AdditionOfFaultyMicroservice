namespace CourseManagement.Domain.Students.Dtos;

using CourseManagement.Resources;

public sealed class StudentParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
