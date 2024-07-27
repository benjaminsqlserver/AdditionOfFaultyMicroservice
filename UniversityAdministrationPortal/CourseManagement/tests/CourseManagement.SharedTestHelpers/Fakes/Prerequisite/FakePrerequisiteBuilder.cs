namespace CourseManagement.SharedTestHelpers.Fakes.Prerequisite;

using CourseManagement.Domain.Prerequisites;
using CourseManagement.Domain.Prerequisites.Models;

public class FakePrerequisiteBuilder
{
    private PrerequisiteForCreation _creationData = new FakePrerequisiteForCreation().Generate();

    public FakePrerequisiteBuilder WithModel(PrerequisiteForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakePrerequisiteBuilder WithCourseID(Guid courseID)
    {
        _creationData.CourseID = courseID;
        return this;
    }
    
    public FakePrerequisiteBuilder WithPrerequisiteCourseID(Guid prerequisiteCourseID)
    {
        _creationData.PrerequisiteCourseID = prerequisiteCourseID;
        return this;
    }
    
    public Prerequisite Build()
    {
        var result = Prerequisite.Create(_creationData);
        return result;
    }
}