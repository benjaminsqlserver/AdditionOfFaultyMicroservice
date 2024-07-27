namespace CourseManagement.UnitTests.Domain.LectureHalls;

using CourseManagement.SharedTestHelpers.Fakes.LectureHall;
using CourseManagement.Domain.LectureHalls;
using CourseManagement.Domain.LectureHalls.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class CreateLectureHallTests
{
    private readonly Faker _faker;

    public CreateLectureHallTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_lectureHall()
    {
        // Arrange
        var lectureHallToCreate = new FakeLectureHallForCreation().Generate();
        
        // Act
        var lectureHall = LectureHall.Create(lectureHallToCreate);

        // Assert
        lectureHall.RoomNumber.Should().Be(lectureHallToCreate.RoomNumber);
        lectureHall.Capacity.Should().Be(lectureHallToCreate.Capacity);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var lectureHallToCreate = new FakeLectureHallForCreation().Generate();
        
        // Act
        var lectureHall = LectureHall.Create(lectureHallToCreate);

        // Assert
        lectureHall.DomainEvents.Count.Should().Be(1);
        lectureHall.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(LectureHallCreated));
    }
}