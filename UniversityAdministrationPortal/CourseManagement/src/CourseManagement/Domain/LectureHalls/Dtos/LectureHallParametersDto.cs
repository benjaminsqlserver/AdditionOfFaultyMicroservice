namespace CourseManagement.Domain.LectureHalls.Dtos;

using CourseManagement.Resources;

public sealed class LectureHallParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
