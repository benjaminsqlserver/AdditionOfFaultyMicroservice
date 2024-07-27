namespace CourseManagement.SharedTestHelpers.Fakes.Schedule;

using AutoBogus;
using CourseManagement.Domain.Schedules;
using CourseManagement.Domain.Schedules.Dtos;

public sealed class FakeScheduleForCreationDto : AutoFaker<ScheduleForCreationDto>
{
    public FakeScheduleForCreationDto()
    {
    }
}