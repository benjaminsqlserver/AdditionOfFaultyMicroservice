namespace CourseManagement.FunctionalTests.FunctionalTests.LectureHalls;

using CourseManagement.SharedTestHelpers.Fakes.LectureHall;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetLectureHallTests : TestBase
{
    [Fact]
    public async Task get_lecturehall_returns_success_when_entity_exists()
    {
        // Arrange
        var lectureHall = new FakeLectureHallBuilder().Build();
        await InsertAsync(lectureHall);

        // Act
        var route = ApiRoutes.LectureHalls.GetRecord(lectureHall.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}