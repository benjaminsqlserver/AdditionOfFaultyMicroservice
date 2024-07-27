namespace FacultyManagement.Domain.Schedules.Mappings;

using FacultyManagement.Domain.Schedules.Dtos;
using FacultyManagement.Domain.Schedules.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class ScheduleMapper
{
    public static partial ScheduleForCreation ToScheduleForCreation(this ScheduleForCreationDto scheduleForCreationDto);
    public static partial ScheduleForUpdate ToScheduleForUpdate(this ScheduleForUpdateDto scheduleForUpdateDto);
    public static partial ScheduleDto ToScheduleDto(this Schedule schedule);
    public static partial IQueryable<ScheduleDto> ToScheduleDtoQueryable(this IQueryable<Schedule> schedule);
}