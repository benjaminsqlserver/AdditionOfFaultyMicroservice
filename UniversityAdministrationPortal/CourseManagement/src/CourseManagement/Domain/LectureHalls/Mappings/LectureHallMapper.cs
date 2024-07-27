namespace CourseManagement.Domain.LectureHalls.Mappings;

using CourseManagement.Domain.LectureHalls.Dtos;
using CourseManagement.Domain.LectureHalls.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class LectureHallMapper
{
    public static partial LectureHallForCreation ToLectureHallForCreation(this LectureHallForCreationDto lectureHallForCreationDto);
    public static partial LectureHallForUpdate ToLectureHallForUpdate(this LectureHallForUpdateDto lectureHallForUpdateDto);
    public static partial LectureHallDto ToLectureHallDto(this LectureHall lectureHall);
    public static partial IQueryable<LectureHallDto> ToLectureHallDtoQueryable(this IQueryable<LectureHall> lectureHall);
}