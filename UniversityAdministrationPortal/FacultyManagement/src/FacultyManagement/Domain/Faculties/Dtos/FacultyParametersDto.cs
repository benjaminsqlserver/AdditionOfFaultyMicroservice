namespace FacultyManagement.Domain.Faculties.Dtos;

using FacultyManagement.Resources;

public sealed class FacultyParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
