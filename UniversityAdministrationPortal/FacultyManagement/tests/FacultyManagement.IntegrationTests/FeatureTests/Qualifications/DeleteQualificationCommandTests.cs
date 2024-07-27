namespace FacultyManagement.IntegrationTests.FeatureTests.Qualifications;

using FacultyManagement.SharedTestHelpers.Fakes.Qualification;
using FacultyManagement.Domain.Qualifications.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteQualificationCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_qualification_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var qualification = new FakeQualificationBuilder().Build();
        await testingServiceScope.InsertAsync(qualification);

        // Act
        var command = new DeleteQualification.Command(qualification.Id);
        await testingServiceScope.SendAsync(command);
        var qualificationResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Qualifications
                .CountAsync(q => q.Id == qualification.Id));

        // Assert
        qualificationResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_qualification_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteQualification.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_qualification_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var qualification = new FakeQualificationBuilder().Build();
        await testingServiceScope.InsertAsync(qualification);

        // Act
        var command = new DeleteQualification.Command(qualification.Id);
        await testingServiceScope.SendAsync(command);
        var deletedQualification = await testingServiceScope.ExecuteDbContextAsync(db => db.Qualifications
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == qualification.Id));

        // Assert
        deletedQualification?.IsDeleted.Should().BeTrue();
    }
}