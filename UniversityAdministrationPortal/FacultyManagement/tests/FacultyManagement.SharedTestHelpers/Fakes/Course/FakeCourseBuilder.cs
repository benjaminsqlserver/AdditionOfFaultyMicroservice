namespace FacultyManagement.SharedTestHelpers.Fakes.Course;

using FacultyManagement.Domain.Courses;
using FacultyManagement.Domain.Courses.Models;

public class FakeCourseBuilder
{
    private CourseForCreation _creationData = new FakeCourseForCreation().Generate();

    public FakeCourseBuilder WithModel(CourseForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeCourseBuilder WithCourseCode(string courseCode)
    {
        _creationData.CourseCode = courseCode;
        return this;
    }
    
    public FakeCourseBuilder WithCourseName(string courseName)
    {
        _creationData.CourseName = courseName;
        return this;
    }
    
    public FakeCourseBuilder WithCredits(int credits)
    {
        _creationData.Credits = credits;
        return this;
    }
    
    public Course Build()
    {
        var result = Course.Create(_creationData);
        return result;
    }
}