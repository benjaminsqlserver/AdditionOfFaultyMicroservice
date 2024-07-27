namespace FacultyManagement.IntegrationTests.FeatureTests.Faculties;

using FacultyManagement.SharedTestHelpers.Fakes.Faculty;
using FacultyManagement.Domain.Faculties.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteFacultyCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_faculty_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var faculty = new FakeFacultyBuilder().Build();
        await testingServiceScope.InsertAsync(faculty);

        // Act
        var command = new DeleteFaculty.Command(faculty.Id);
        await testingServiceScope.SendAsync(command);
        var facultyResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Faculties
                .CountAsync(f => f.Id == faculty.Id));

        // Assert
        facultyResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_faculty_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteFaculty.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_faculty_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var faculty = new FakeFacultyBuilder().Build();
        await testingServiceScope.InsertAsync(faculty);

        // Act
        var command = new DeleteFaculty.Command(faculty.Id);
        await testingServiceScope.SendAsync(command);
        var deletedFaculty = await testingServiceScope.ExecuteDbContextAsync(db => db.Faculties
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == faculty.Id));

        // Assert
        deletedFaculty?.IsDeleted.Should().BeTrue();
    }
}