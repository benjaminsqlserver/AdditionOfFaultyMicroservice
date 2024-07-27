namespace CourseManagement.SharedTestHelpers.Fakes.Schedule;

using AutoBogus;
using CourseManagement.Domain.Schedules;
using CourseManagement.Domain.Schedules.Models;

public sealed class FakeScheduleForUpdate : AutoFaker<ScheduleForUpdate>
{
    public FakeScheduleForUpdate()
    {
    }
}