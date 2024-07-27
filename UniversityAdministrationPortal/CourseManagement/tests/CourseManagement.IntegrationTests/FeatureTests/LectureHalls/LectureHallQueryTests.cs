namespace CourseManagement.IntegrationTests.FeatureTests.LectureHalls;

using CourseManagement.SharedTestHelpers.Fakes.LectureHall;
using CourseManagement.Domain.LectureHalls.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class LectureHallQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_lecturehall_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var lectureHallOne = new FakeLectureHallBuilder().Build();
        await testingServiceScope.InsertAsync(lectureHallOne);

        // Act
        var query = new GetLectureHall.Query(lectureHallOne.Id);
        var lectureHall = await testingServiceScope.SendAsync(query);

        // Assert
        lectureHall.RoomNumber.Should().Be(lectureHallOne.RoomNumber);
        lectureHall.Capacity.Should().Be(lectureHallOne.Capacity);
    }

    [Fact]
    public async Task get_lecturehall_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetLectureHall.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}