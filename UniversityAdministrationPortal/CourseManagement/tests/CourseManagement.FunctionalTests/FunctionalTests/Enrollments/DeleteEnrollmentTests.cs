namespace CourseManagement.FunctionalTests.FunctionalTests.Enrollments;

using CourseManagement.SharedTestHelpers.Fakes.Enrollment;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteEnrollmentTests : TestBase
{
    [Fact]
    public async Task delete_enrollment_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var enrollment = new FakeEnrollmentBuilder().Build();
        await InsertAsync(enrollment);

        // Act
        var route = ApiRoutes.Enrollments.Delete(enrollment.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}