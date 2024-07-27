namespace FacultyManagement.SharedTestHelpers.Fakes.CourseAssignment;

using FacultyManagement.Domain.CourseAssignments;
using FacultyManagement.Domain.CourseAssignments.Models;

public class FakeCourseAssignmentBuilder
{
    private CourseAssignmentForCreation _creationData = new FakeCourseAssignmentForCreation().Generate();

    public FakeCourseAssignmentBuilder WithModel(CourseAssignmentForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeCourseAssignmentBuilder WithFacultyID(Guid facultyID)
    {
        _creationData.FacultyID = facultyID;
        return this;
    }
    
    public FakeCourseAssignmentBuilder WithCourseID(Guid courseID)
    {
        _creationData.CourseID = courseID;
        return this;
    }
    
    public FakeCourseAssignmentBuilder WithAssignmentDate(DateTime assignmentDate)
    {
        _creationData.AssignmentDate = assignmentDate;
        return this;
    }
    
    public CourseAssignment Build()
    {
        var result = CourseAssignment.Create(_creationData);
        return result;
    }
}