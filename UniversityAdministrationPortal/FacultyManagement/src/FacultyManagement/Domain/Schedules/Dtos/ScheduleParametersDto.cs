namespace FacultyManagement.Domain.Schedules.Dtos;

using FacultyManagement.Resources;

public sealed class ScheduleParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
