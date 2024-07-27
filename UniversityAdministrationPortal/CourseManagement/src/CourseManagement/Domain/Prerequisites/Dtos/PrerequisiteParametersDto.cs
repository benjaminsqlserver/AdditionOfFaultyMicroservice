namespace CourseManagement.Domain.Prerequisites.Dtos;

using CourseManagement.Resources;

public sealed class PrerequisiteParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
