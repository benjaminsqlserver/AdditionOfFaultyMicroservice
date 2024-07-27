namespace CourseManagement.SharedTestHelpers.Fakes.Enrollment;

using CourseManagement.Domain.Enrollments;
using CourseManagement.Domain.Enrollments.Models;

public class FakeEnrollmentBuilder
{
    private EnrollmentForCreation _creationData = new FakeEnrollmentForCreation().Generate();

    public FakeEnrollmentBuilder WithModel(EnrollmentForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeEnrollmentBuilder WithEnrollmentDate(DateTime enrollmentDate)
    {
        _creationData.EnrollmentDate = enrollmentDate;
        return this;
    }
    
    public FakeEnrollmentBuilder WithStudentID(Guid studentID)
    {
        _creationData.StudentID = studentID;
        return this;
    }
    
    public FakeEnrollmentBuilder WithCourseID(Guid courseID)
    {
        _creationData.CourseID = courseID;
        return this;
    }
    
    public Enrollment Build()
    {
        var result = Enrollment.Create(_creationData);
        return result;
    }
}