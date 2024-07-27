namespace FacultyManagement.SharedTestHelpers.Fakes.Schedule;

using FacultyManagement.Domain.Schedules;
using FacultyManagement.Domain.Schedules.Models;

public class FakeScheduleBuilder
{
    private ScheduleForCreation _creationData = new FakeScheduleForCreation().Generate();

    public FakeScheduleBuilder WithModel(ScheduleForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeScheduleBuilder WithFacultyID(Guid facultyID)
    {
        _creationData.FacultyID = facultyID;
        return this;
    }
    
    public FakeScheduleBuilder WithDayOfWeek(string dayOfWeek)
    {
        _creationData.DayOfWeek = dayOfWeek;
        return this;
    }
    
    public FakeScheduleBuilder WithStartTime(DateTime startTime)
    {
        _creationData.StartTime = startTime;
        return this;
    }
    
    public FakeScheduleBuilder WithEndTime(DateTime endTime)
    {
        _creationData.EndTime = endTime;
        return this;
    }
    
    public FakeScheduleBuilder WithIsOfficeHour(bool isOfficeHour)
    {
        _creationData.IsOfficeHour = isOfficeHour;
        return this;
    }
    
    public Schedule Build()
    {
        var result = Schedule.Create(_creationData);
        return result;
    }
}