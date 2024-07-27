namespace CourseManagement.FunctionalTests.FunctionalTests.Enrollments;

using CourseManagement.SharedTestHelpers.Fakes.Enrollment;
using CourseManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetEnrollmentTests : TestBase
{
    [Fact]
    public async Task get_enrollment_returns_success_when_entity_exists()
    {
        // Arrange
        var enrollment = new FakeEnrollmentBuilder().Build();
        await InsertAsync(enrollment);

        // Act
        var route = ApiRoutes.Enrollments.GetRecord(enrollment.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}