namespace CourseManagement.Domain.Schedules.Dtos;

using CourseManagement.Resources;

public sealed class ScheduleParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
