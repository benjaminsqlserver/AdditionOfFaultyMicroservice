namespace FacultyManagement.SharedTestHelpers.Fakes.Qualification;

using FacultyManagement.Domain.Qualifications;
using FacultyManagement.Domain.Qualifications.Models;

public class FakeQualificationBuilder
{
    private QualificationForCreation _creationData = new FakeQualificationForCreation().Generate();

    public FakeQualificationBuilder WithModel(QualificationForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeQualificationBuilder WithFacultyID(Guid facultyID)
    {
        _creationData.FacultyID = facultyID;
        return this;
    }
    
    public FakeQualificationBuilder WithDegree(string degree)
    {
        _creationData.Degree = degree;
        return this;
    }
    
    public FakeQualificationBuilder WithInstitution(string institution)
    {
        _creationData.Institution = institution;
        return this;
    }
    
    public FakeQualificationBuilder WithYearOfCompletion(int yearOfCompletion)
    {
        _creationData.YearOfCompletion = yearOfCompletion;
        return this;
    }
    
    public Qualification Build()
    {
        var result = Qualification.Create(_creationData);
        return result;
    }
}