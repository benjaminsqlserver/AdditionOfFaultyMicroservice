namespace FacultyManagement.IntegrationTests.FeatureTests.Qualifications;

using FacultyManagement.Domain.Qualifications.Dtos;
using FacultyManagement.SharedTestHelpers.Fakes.Qualification;
using FacultyManagement.Domain.Qualifications.Features;
using Domain;
using System.Threading.Tasks;

public class QualificationListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_qualification_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var qualificationOne = new FakeQualificationBuilder().Build();
        var qualificationTwo = new FakeQualificationBuilder().Build();
        var queryParameters = new QualificationParametersDto();

        await testingServiceScope.InsertAsync(qualificationOne, qualificationTwo);

        // Act
        var query = new GetQualificationList.Query(queryParameters);
        var qualifications = await testingServiceScope.SendAsync(query);

        // Assert
        qualifications.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}