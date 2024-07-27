namespace FacultyManagement.Domain.Evaluations.Dtos;

using FacultyManagement.Resources;

public sealed class EvaluationParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
