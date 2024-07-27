namespace CourseManagement.FunctionalTests.FunctionalTests.LectureHalls;

using CourseManagement.SharedTestHelpers.Fakes.LectureHall;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteLectureHallTests : TestBase
{
    [Fact]
    public async Task delete_lecturehall_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var lectureHall = new FakeLectureHallBuilder().Build();
        await InsertAsync(lectureHall);

        // Act
        var route = ApiRoutes.LectureHalls.Delete(lectureHall.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}