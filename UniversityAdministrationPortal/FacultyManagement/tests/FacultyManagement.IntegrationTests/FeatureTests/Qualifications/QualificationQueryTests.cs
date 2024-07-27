namespace FacultyManagement.IntegrationTests.FeatureTests.Qualifications;

using FacultyManagement.SharedTestHelpers.Fakes.Qualification;
using FacultyManagement.Domain.Qualifications.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class QualificationQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_qualification_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var qualificationOne = new FakeQualificationBuilder().Build();
        await testingServiceScope.InsertAsync(qualificationOne);

        // Act
        var query = new GetQualification.Query(qualificationOne.Id);
        var qualification = await testingServiceScope.SendAsync(query);

        // Assert
        qualification.FacultyID.Should().Be(qualificationOne.FacultyID);
        qualification.Degree.Should().Be(qualificationOne.Degree);
        qualification.Institution.Should().Be(qualificationOne.Institution);
        qualification.YearOfCompletion.Should().Be(qualificationOne.YearOfCompletion);
    }

    [Fact]
    public async Task get_qualification_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetQualification.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}