namespace CourseManagement.IntegrationTests.FeatureTests.Prerequisites;

using CourseManagement.SharedTestHelpers.Fakes.Prerequisite;
using CourseManagement.Domain.Prerequisites.Dtos;
using CourseManagement.Domain.Prerequisites.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdatePrerequisiteCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_prerequisite_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var prerequisite = new FakePrerequisiteBuilder().Build();
        await testingServiceScope.InsertAsync(prerequisite);
        var updatedPrerequisiteDto = new FakePrerequisiteForUpdateDto().Generate();

        // Act
        var command = new UpdatePrerequisite.Command(prerequisite.Id, updatedPrerequisiteDto);
        await testingServiceScope.SendAsync(command);
        var updatedPrerequisite = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Prerequisites
                .FirstOrDefaultAsync(p => p.Id == prerequisite.Id));

        // Assert
        updatedPrerequisite.CourseID.Should().Be(updatedPrerequisiteDto.CourseID);
        updatedPrerequisite.PrerequisiteCourseID.Should().Be(updatedPrerequisiteDto.PrerequisiteCourseID);
    }
}