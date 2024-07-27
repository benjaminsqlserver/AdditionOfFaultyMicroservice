namespace FacultyManagement.IntegrationTests.FeatureTests.Qualifications;

using FacultyManagement.SharedTestHelpers.Fakes.Qualification;
using FacultyManagement.Domain.Qualifications.Dtos;
using FacultyManagement.Domain.Qualifications.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateQualificationCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_qualification_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var qualification = new FakeQualificationBuilder().Build();
        await testingServiceScope.InsertAsync(qualification);
        var updatedQualificationDto = new FakeQualificationForUpdateDto().Generate();

        // Act
        var command = new UpdateQualification.Command(qualification.Id, updatedQualificationDto);
        await testingServiceScope.SendAsync(command);
        var updatedQualification = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Qualifications
                .FirstOrDefaultAsync(q => q.Id == qualification.Id));

        // Assert
        updatedQualification.FacultyID.Should().Be(updatedQualificationDto.FacultyID);
        updatedQualification.Degree.Should().Be(updatedQualificationDto.Degree);
        updatedQualification.Institution.Should().Be(updatedQualificationDto.Institution);
        updatedQualification.YearOfCompletion.Should().Be(updatedQualificationDto.YearOfCompletion);
    }
}