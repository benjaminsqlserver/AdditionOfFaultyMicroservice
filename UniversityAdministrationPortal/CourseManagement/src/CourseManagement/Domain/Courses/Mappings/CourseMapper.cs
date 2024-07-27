namespace CourseManagement.Domain.Courses.Mappings;

using CourseManagement.Domain.Courses.Dtos;
using CourseManagement.Domain.Courses.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class CourseMapper
{
    public static partial CourseForCreation ToCourseForCreation(this CourseForCreationDto courseForCreationDto);
    public static partial CourseForUpdate ToCourseForUpdate(this CourseForUpdateDto courseForUpdateDto);
    public static partial CourseDto ToCourseDto(this Course course);
    public static partial IQueryable<CourseDto> ToCourseDtoQueryable(this IQueryable<Course> course);
}