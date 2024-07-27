namespace FacultyManagement.UnitTests.Domain.Schedules;

using FacultyManagement.SharedTestHelpers.Fakes.Schedule;
using FacultyManagement.Domain.Schedules;
using FacultyManagement.Domain.Schedules.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = FacultyManagement.Exceptions.ValidationException;

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
        schedule.FacultyID.Should().Be(scheduleToCreate.FacultyID);
        schedule.DayOfWeek.Should().Be(scheduleToCreate.DayOfWeek);
        schedule.StartTime.Should().BeCloseTo(scheduleToCreate.StartTime, 1.Seconds());
        schedule.EndTime.Should().BeCloseTo(scheduleToCreate.EndTime, 1.Seconds());
        schedule.IsOfficeHour.Should().Be(scheduleToCreate.IsOfficeHour);
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