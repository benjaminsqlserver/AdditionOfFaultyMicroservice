namespace CourseManagement.IntegrationTests.FeatureTests.Instructors;

using CourseManagement.SharedTestHelpers.Fakes.Instructor;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CourseManagement.Domain.Instructors.Features;

public class AddInstructorCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_instructor_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var instructorOne = new FakeInstructorForCreationDto().Generate();

        // Act
        var command = new AddInstructor.Command(instructorOne);
        var instructorReturned = await testingServiceScope.SendAsync(command);
        var instructorCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Instructors
            .FirstOrDefaultAsync(i => i.Id == instructorReturned.Id));

        // Assert
        instructorReturned.FirstName.Should().Be(instructorOne.FirstName);
        instructorReturned.LastName.Should().Be(instructorOne.LastName);
        instructorReturned.Email.Should().Be(instructorOne.Email);

        instructorCreated.FirstName.Should().Be(instructorOne.FirstName);
        instructorCreated.LastName.Should().Be(instructorOne.LastName);
        instructorCreated.Email.Should().Be(instructorOne.Email);
    }
}