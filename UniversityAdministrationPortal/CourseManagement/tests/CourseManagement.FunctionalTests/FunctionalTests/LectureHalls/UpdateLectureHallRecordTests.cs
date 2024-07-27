namespace CourseManagement.FunctionalTests.FunctionalTests.LectureHalls;

using CourseManagement.SharedTestHelpers.Fakes.LectureHall;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateLectureHallRecordTests : TestBase
{
    [Fact]
    public async Task put_lecturehall_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var lectureHall = new FakeLectureHallBuilder().Build();
        var updatedLectureHallDto = new FakeLectureHallForUpdateDto().Generate();
        await InsertAsync(lectureHall);

        // Act
        var route = ApiRoutes.LectureHalls.Put(lectureHall.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedLectureHallDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}