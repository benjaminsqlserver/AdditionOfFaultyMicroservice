namespace FacultyManagement.Domain.CourseAssignments.Mappings;

using FacultyManagement.Domain.CourseAssignments.Dtos;
using FacultyManagement.Domain.CourseAssignments.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class CourseAssignmentMapper
{
    public static partial CourseAssignmentForCreation ToCourseAssignmentForCreation(this CourseAssignmentForCreationDto courseAssignmentForCreationDto);
    public static partial CourseAssignmentForUpdate ToCourseAssignmentForUpdate(this CourseAssignmentForUpdateDto courseAssignmentForUpdateDto);
    public static partial CourseAssignmentDto ToCourseAssignmentDto(this CourseAssignment courseAssignment);
    public static partial IQueryable<CourseAssignmentDto> ToCourseAssignmentDtoQueryable(this IQueryable<CourseAssignment> courseAssignment);
}