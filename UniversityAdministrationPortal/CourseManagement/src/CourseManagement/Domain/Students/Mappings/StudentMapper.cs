namespace CourseManagement.Domain.Students.Mappings;

using CourseManagement.Domain.Students.Dtos;
using CourseManagement.Domain.Students.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class StudentMapper
{
    public static partial StudentForCreation ToStudentForCreation(this StudentForCreationDto studentForCreationDto);
    public static partial StudentForUpdate ToStudentForUpdate(this StudentForUpdateDto studentForUpdateDto);
    public static partial StudentDto ToStudentDto(this Student student);
    public static partial IQueryable<StudentDto> ToStudentDtoQueryable(this IQueryable<Student> student);
}