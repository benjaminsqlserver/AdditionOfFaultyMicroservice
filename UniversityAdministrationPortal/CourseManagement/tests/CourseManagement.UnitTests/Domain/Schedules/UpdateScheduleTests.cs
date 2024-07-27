namespace CourseManagement.UnitTests.Domain.Schedules;

using CourseManagement.SharedTestHelpers.Fakes.Schedule;
using CourseManagement.Domain.Schedules;
using CourseManagement.Domain.Schedules.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class UpdateScheduleTests
{
    private readonly Faker _faker;

    public UpdateScheduleTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_schedule()
    {
        // Arrange
        var schedule = new FakeScheduleBuilder().Build();
        var updatedSchedule = new FakeScheduleForUpdate().Generate();
        
        // Act
        schedule.Update(updatedSchedule);

        // Assert
        schedule.ClassTiming.Should().BeCloseTo(updatedSchedule.ClassTiming, 1.Seconds());
        schedule.Location.Should().Be(updatedSchedule.Location);
        schedule.CourseID.Should().Be(updatedSchedule.CourseID);
        schedule.InstructorID.Should().Be(updatedSchedule.InstructorID);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var schedule = new FakeScheduleBuilder().Build();
        var updatedSchedule = new FakeScheduleForUpdate().Generate();
        schedule.DomainEvents.Clear();
        
        // Act
        schedule.Update(updatedSchedule);

        // Assert
        schedule.DomainEvents.Count.Should().Be(1);
        schedule.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ScheduleUpdated));
    }
}