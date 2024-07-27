namespace CourseManagement.IntegrationTests.FeatureTests.LectureHalls;

using CourseManagement.SharedTestHelpers.Fakes.LectureHall;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CourseManagement.Domain.LectureHalls.Features;

public class AddLectureHallCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_lecturehall_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var lectureHallOne = new FakeLectureHallForCreationDto().Generate();

        // Act
        var command = new AddLectureHall.Command(lectureHallOne);
        var lectureHallReturned = await testingServiceScope.SendAsync(command);
        var lectureHallCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.LectureHalls
            .FirstOrDefaultAsync(l => l.Id == lectureHallReturned.Id));

        // Assert
        lectureHallReturned.RoomNumber.Should().Be(lectureHallOne.RoomNumber);
        lectureHallReturned.Capacity.Should().Be(lectureHallOne.Capacity);

        lectureHallCreated.RoomNumber.Should().Be(lectureHallOne.RoomNumber);
        lectureHallCreated.Capacity.Should().Be(lectureHallOne.Capacity);
    }
}