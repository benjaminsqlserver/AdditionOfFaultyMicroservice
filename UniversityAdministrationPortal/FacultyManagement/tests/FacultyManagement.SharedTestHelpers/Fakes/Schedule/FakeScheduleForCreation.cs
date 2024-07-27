namespace FacultyManagement.SharedTestHelpers.Fakes.Schedule;

using AutoBogus;
using FacultyManagement.Domain.Schedules;
using FacultyManagement.Domain.Schedules.Models;

public sealed class FakeScheduleForCreation : AutoFaker<ScheduleForCreation>
{
    public FakeScheduleForCreation()
    {
    }
}