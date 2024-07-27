namespace CourseManagement.Domain.Instructors.Mappings;

using CourseManagement.Domain.Instructors.Dtos;
using CourseManagement.Domain.Instructors.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class InstructorMapper
{
    public static partial InstructorForCreation ToInstructorForCreation(this InstructorForCreationDto instructorForCreationDto);
    public static partial InstructorForUpdate ToInstructorForUpdate(this InstructorForUpdateDto instructorForUpdateDto);
    public static partial InstructorDto ToInstructorDto(this Instructor instructor);
    public static partial IQueryable<InstructorDto> ToInstructorDtoQueryable(this IQueryable<Instructor> instructor);
}