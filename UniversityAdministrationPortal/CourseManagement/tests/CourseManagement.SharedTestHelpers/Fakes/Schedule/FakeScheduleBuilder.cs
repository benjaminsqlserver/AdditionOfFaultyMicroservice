namespace CourseManagement.SharedTestHelpers.Fakes.Schedule;

using CourseManagement.Domain.Schedules;
using CourseManagement.Domain.Schedules.Models;

public class FakeScheduleBuilder
{
    private ScheduleForCreation _creationData = new FakeScheduleForCreation().Generate();

    public FakeScheduleBuilder WithModel(ScheduleForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeScheduleBuilder WithClassTiming(DateTime classTiming)
    {
        _creationData.ClassTiming = classTiming;
        return this;
    }
    
    public FakeScheduleBuilder WithLocation(string location)
    {
        _creationData.Location = location;
        return this;
    }
    
    public FakeScheduleBuilder WithCourseID(Guid courseID)
    {
        _creationData.CourseID = courseID;
        return this;
    }
    
    public FakeScheduleBuilder WithInstructorID(Guid instructorID)
    {
        _creationData.InstructorID = instructorID;
        return this;
    }
    
    public Schedule Build()
    {
        var result = Schedule.Create(_creationData);
        return result;
    }
}