namespace CourseManagement.Domain.Prerequisites.Mappings;

using CourseManagement.Domain.Prerequisites.Dtos;
using CourseManagement.Domain.Prerequisites.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class PrerequisiteMapper
{
    public static partial PrerequisiteForCreation ToPrerequisiteForCreation(this PrerequisiteForCreationDto prerequisiteForCreationDto);
    public static partial PrerequisiteForUpdate ToPrerequisiteForUpdate(this PrerequisiteForUpdateDto prerequisiteForUpdateDto);
    public static partial PrerequisiteDto ToPrerequisiteDto(this Prerequisite prerequisite);
    public static partial IQueryable<PrerequisiteDto> ToPrerequisiteDtoQueryable(this IQueryable<Prerequisite> prerequisite);
}