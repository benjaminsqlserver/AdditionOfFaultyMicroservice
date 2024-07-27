namespace CourseManagement.UnitTests.Domain.LectureHalls;

using CourseManagement.SharedTestHelpers.Fakes.LectureHall;
using CourseManagement.Domain.LectureHalls;
using CourseManagement.Domain.LectureHalls.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = CourseManagement.Exceptions.ValidationException;

public class UpdateLectureHallTests
{
    private readonly Faker _faker;

    public UpdateLectureHallTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_lectureHall()
    {
        // Arrange
        var lectureHall = new FakeLectureHallBuilder().Build();
        var updatedLectureHall = new FakeLectureHallForUpdate().Generate();
        
        // Act
        lectureHall.Update(updatedLectureHall);

        // Assert
        lectureHall.RoomNumber.Should().Be(updatedLectureHall.RoomNumber);
        lectureHall.Capacity.Should().Be(updatedLectureHall.Capacity);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var lectureHall = new FakeLectureHallBuilder().Build();
        var updatedLectureHall = new FakeLectureHallForUpdate().Generate();
        lectureHall.DomainEvents.Clear();
        
        // Act
        lectureHall.Update(updatedLectureHall);

        // Assert
        lectureHall.DomainEvents.Count.Should().Be(1);
        lectureHall.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(LectureHallUpdated));
    }
}