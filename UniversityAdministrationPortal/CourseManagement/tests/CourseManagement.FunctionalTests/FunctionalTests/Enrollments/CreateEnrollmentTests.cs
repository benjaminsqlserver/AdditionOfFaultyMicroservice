namespace CourseManagement.FunctionalTests.FunctionalTests.Enrollments;

using CourseManagement.SharedTestHelpers.Fakes.Enrollment;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateEnrollmentTests : TestBase
{
    [Fact]
    public async Task create_enrollment_returns_created_using_valid_dto()
    {
        // Arrange
        var enrollment = new FakeEnrollmentForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Enrollments.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, enrollment);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}