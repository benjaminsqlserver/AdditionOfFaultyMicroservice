namespace FacultyManagement.Domain.Qualifications.Mappings;

using FacultyManagement.Domain.Qualifications.Dtos;
using FacultyManagement.Domain.Qualifications.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class QualificationMapper
{
    public static partial QualificationForCreation ToQualificationForCreation(this QualificationForCreationDto qualificationForCreationDto);
    public static partial QualificationForUpdate ToQualificationForUpdate(this QualificationForUpdateDto qualificationForUpdateDto);
    public static partial QualificationDto ToQualificationDto(this Qualification qualification);
    public static partial IQueryable<QualificationDto> ToQualificationDtoQueryable(this IQueryable<Qualification> qualification);
}