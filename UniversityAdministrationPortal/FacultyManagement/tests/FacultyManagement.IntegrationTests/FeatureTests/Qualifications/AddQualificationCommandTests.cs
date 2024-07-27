namespace FacultyManagement.IntegrationTests.FeatureTests.Qualifications;

using FacultyManagement.SharedTestHelpers.Fakes.Qualification;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FacultyManagement.Domain.Qualifications.Features;

public class AddQualificationCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_qualification_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var qualificationOne = new FakeQualificationForCreationDto().Generate();

        // Act
        var command = new AddQualification.Command(qualificationOne);
        var qualificationReturned = await testingServiceScope.SendAsync(command);
        var qualificationCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Qualifications
            .FirstOrDefaultAsync(q => q.Id == qualificationReturned.Id));

        // Assert
        qualificationReturned.FacultyID.Should().Be(qualificationOne.FacultyID);
        qualificationReturned.Degree.Should().Be(qualificationOne.Degree);
        qualificationReturned.Institution.Should().Be(qualificationOne.Institution);
        qualificationReturned.YearOfCompletion.Should().Be(qualificationOne.YearOfCompletion);

        qualificationCreated.FacultyID.Should().Be(qualificationOne.FacultyID);
        qualificationCreated.Degree.Should().Be(qualificationOne.Degree);
        qualificationCreated.Institution.Should().Be(qualificationOne.Institution);
        qualificationCreated.YearOfCompletion.Should().Be(qualificationOne.YearOfCompletion);
    }
}