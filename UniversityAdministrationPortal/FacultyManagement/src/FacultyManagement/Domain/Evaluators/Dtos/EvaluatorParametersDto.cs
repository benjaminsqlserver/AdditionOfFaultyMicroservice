namespace FacultyManagement.Domain.Evaluators.Dtos;

using FacultyManagement.Resources;

public sealed class EvaluatorParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
