namespace FacultyManagement.Domain.Qualifications.Dtos;

using FacultyManagement.Resources;

public sealed class QualificationParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
