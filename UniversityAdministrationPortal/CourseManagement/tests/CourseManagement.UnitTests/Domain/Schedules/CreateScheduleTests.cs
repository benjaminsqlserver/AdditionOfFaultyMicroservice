namespace CourseManagement.UnitTests.Domain.Schedules;

using CourseManagement.SharedTestHelpers.Fakes.Schedule;
using CourseManagement.Domain.Schedules;
using CourseManagement.Domain.Schedules.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class CreateScheduleTests
{
    private readonly Faker _faker;

    public CreateScheduleTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_schedule()
    {
        // Arrange
        var scheduleToCreate = new FakeScheduleForCreation().Generate();
        
        // Act
        var schedule = Schedule.Create(scheduleToCreate);

        // Assert
        schedule.ClassTiming.Should().BeCloseTo(scheduleToCreate.ClassTiming, 1.Seconds());
        schedule.Location.Should().Be(scheduleToCreate.Location);
        schedule.CourseID.Should().Be(scheduleToCreate.CourseID);
        schedule.InstructorID.Should().Be(scheduleToCreate.InstructorID);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var scheduleToCreate = new FakeScheduleForCreation().Generate();
        
        // Act
        var schedule = Schedule.Create(scheduleToCreate);

        // Assert
        schedule.DomainEvents.Count.Should().Be(1);
        schedule.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ScheduleCreated));
    }
}