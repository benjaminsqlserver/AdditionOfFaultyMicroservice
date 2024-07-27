namespace CourseManagement.Domain.Resources.Dtos;

using CourseManagement.Resources;

public sealed class ResourceParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
