namespace FacultyManagement.SharedTestHelpers.Fakes.Schedule;

using AutoBogus;
using FacultyManagement.Domain.Schedules;
using FacultyManagement.Domain.Schedules.Dtos;

public sealed class FakeScheduleForCreationDto : AutoFaker<ScheduleForCreationDto>
{
    public FakeScheduleForCreationDto()
    {
    }
}