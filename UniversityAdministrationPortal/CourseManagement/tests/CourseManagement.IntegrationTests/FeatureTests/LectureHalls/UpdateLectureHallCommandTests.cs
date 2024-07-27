namespace CourseManagement.IntegrationTests.FeatureTests.LectureHalls;

using CourseManagement.SharedTestHelpers.Fakes.LectureHall;
using CourseManagement.Domain.LectureHalls.Dtos;
using CourseManagement.Domain.LectureHalls.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateLectureHallCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_lecturehall_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var lectureHall = new FakeLectureHallBuilder().Build();
        await testingServiceScope.InsertAsync(lectureHall);
        var updatedLectureHallDto = new FakeLectureHallForUpdateDto().Generate();

        // Act
        var command = new UpdateLectureHall.Command(lectureHall.Id, updatedLectureHallDto);
        await testingServiceScope.SendAsync(command);
        var updatedLectureHall = await testingServiceScope
            .ExecuteDbContextAsync(db => db.LectureHalls
                .FirstOrDefaultAsync(l => l.Id == lectureHall.Id));

        // Assert
        updatedLectureHall.RoomNumber.Should().Be(updatedLectureHallDto.RoomNumber);
        updatedLectureHall.Capacity.Should().Be(updatedLectureHallDto.Capacity);
    }
}