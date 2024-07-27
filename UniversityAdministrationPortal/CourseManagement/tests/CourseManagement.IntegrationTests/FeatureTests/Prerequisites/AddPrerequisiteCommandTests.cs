namespace CourseManagement.IntegrationTests.FeatureTests.Prerequisites;

using CourseManagement.SharedTestHelpers.Fakes.Prerequisite;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CourseManagement.Domain.Prerequisites.Features;

public class AddPrerequisiteCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_prerequisite_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var prerequisiteOne = new FakePrerequisiteForCreationDto().Generate();

        // Act
        var command = new AddPrerequisite.Command(prerequisiteOne);
        var prerequisiteReturned = await testingServiceScope.SendAsync(command);
        var prerequisiteCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Prerequisites
            .FirstOrDefaultAsync(p => p.Id == prerequisiteReturned.Id));

        // Assert
        prerequisiteReturned.CourseID.Should().Be(prerequisiteOne.CourseID);
        prerequisiteReturned.PrerequisiteCourseID.Should().Be(prerequisiteOne.PrerequisiteCourseID);

        prerequisiteCreated.CourseID.Should().Be(prerequisiteOne.CourseID);
        prerequisiteCreated.PrerequisiteCourseID.Should().Be(prerequisiteOne.PrerequisiteCourseID);
    }
}