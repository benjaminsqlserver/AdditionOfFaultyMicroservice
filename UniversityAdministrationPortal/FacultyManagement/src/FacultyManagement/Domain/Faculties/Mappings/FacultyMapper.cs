namespace FacultyManagement.Domain.Faculties.Mappings;

using FacultyManagement.Domain.Faculties.Dtos;
using FacultyManagement.Domain.Faculties.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class FacultyMapper
{
    public static partial FacultyForCreation ToFacultyForCreation(this FacultyForCreationDto facultyForCreationDto);
    public static partial FacultyForUpdate ToFacultyForUpdate(this FacultyForUpdateDto facultyForUpdateDto);
    public static partial FacultyDto ToFacultyDto(this Faculty faculty);
    public static partial IQueryable<FacultyDto> ToFacultyDtoQueryable(this IQueryable<Faculty> faculty);
}