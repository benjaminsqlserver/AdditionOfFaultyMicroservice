namespace CourseManagement.SharedTestHelpers.Fakes.Course;

using CourseManagement.Domain.Courses;
using CourseManagement.Domain.Courses.Models;

public class FakeCourseBuilder
{
    private CourseForCreation _creationData = new FakeCourseForCreation().Generate();

    public FakeCourseBuilder WithModel(CourseForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeCourseBuilder WithCourseName(string courseName)
    {
        _creationData.CourseName = courseName;
        return this;
    }
    
    public FakeCourseBuilder WithSyllabus(string syllabus)
    {
        _creationData.Syllabus = syllabus;
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