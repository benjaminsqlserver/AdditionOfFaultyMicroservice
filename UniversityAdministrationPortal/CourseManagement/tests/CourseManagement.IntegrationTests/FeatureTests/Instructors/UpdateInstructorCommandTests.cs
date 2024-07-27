namespace CourseManagement.IntegrationTests.FeatureTests.Instructors;

using CourseManagement.SharedTestHelpers.Fakes.Instructor;
using CourseManagement.Domain.Instructors.Dtos;
using CourseManagement.Domain.Instructors.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateInstructorCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_instructor_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var instructor = new FakeInstructorBuilder().Build();
        await testingServiceScope.InsertAsync(instructor);
        var updatedInstructorDto = new FakeInstructorForUpdateDto().Generate();

        // Act
        var command = new UpdateInstructor.Command(instructor.Id, updatedInstructorDto);
        await testingServiceScope.SendAsync(command);
        var updatedInstructor = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Instructors
                .FirstOrDefaultAsync(i => i.Id == instructor.Id));

        // Assert
        updatedInstructor.FirstName.Should().Be(updatedInstructorDto.FirstName);
        updatedInstructor.LastName.Should().Be(updatedInstructorDto.LastName);
        updatedInstructor.Email.Should().Be(updatedInstructorDto.Email);
    }
}