namespace CourseManagement.Domain.Courses;

using System.ComponentModel.DataAnnotations;
using CourseManagement.Domain.Enrollments;
using CourseManagement.Domain.Prerequisites;
using CourseManagement.Domain.Resources;
using CourseManagement.Domain.Schedules;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CourseManagement.Exceptions;
using CourseManagement.Domain.Courses.Models;
using CourseManagement.Domain.Courses.DomainEvents;
using CourseManagement.Domain.Schedules;
using CourseManagement.Domain.Schedules.Models;
using CourseManagement.Domain.Resources;
using CourseManagement.Domain.Resources.Models;
using CourseManagement.Domain.Prerequisites;
using CourseManagement.Domain.Prerequisites.Models;
using CourseManagement.Domain.Enrollments;
using CourseManagement.Domain.Enrollments.Models;


public class Course : BaseEntity
{
    public string CourseName { get; private set; }

    public string Syllabus { get; private set; }

    public int Credits { get; private set; }

    private readonly List<Schedule> _schedules = new();
    public IReadOnlyCollection<Schedule> Schedules => _schedules.AsReadOnly();

    private readonly List<Resource> _resources = new();
    public IReadOnlyCollection<Resource> Resources => _resources.AsReadOnly();

    private readonly List<Prerequisite> _prerequisites = new();
    public IReadOnlyCollection<Prerequisite> Prerequisites => _prerequisites.AsReadOnly();

    private readonly List<Enrollment> _enrollments = new();
    public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Course Create(CourseForCreation courseForCreation)
    {
        var newCourse = new Course();

        newCourse.CourseName = courseForCreation.CourseName;
        newCourse.Syllabus = courseForCreation.Syllabus;
        newCourse.Credits = courseForCreation.Credits;

        newCourse.QueueDomainEvent(new CourseCreated(){ Course = newCourse });
        
        return newCourse;
    }

    public Course Update(CourseForUpdate courseForUpdate)
    {
        CourseName = courseForUpdate.CourseName;
        Syllabus = courseForUpdate.Syllabus;
        Credits = courseForUpdate.Credits;

        QueueDomainEvent(new CourseUpdated(){ Id = Id });
        return this;
    }

    public Course AddSchedule(Schedule schedule)
    {
        _schedules.Add(schedule);
        return this;
    }
    
    public Course RemoveSchedule(Schedule schedule)
    {
        _schedules.RemoveAll(x => x.Id == schedule.Id);
        return this;
    }

    public Course AddResource(Resource resource)
    {
        _resources.Add(resource);
        return this;
    }
    
    public Course RemoveResource(Resource resource)
    {
        _resources.RemoveAll(x => x.Id == resource.Id);
        return this;
    }

    public Course AddPrerequisite(Prerequisite prerequisite)
    {
        _prerequisites.Add(prerequisite);
        return this;
    }
    
    public Course RemovePrerequisite(Prerequisite prerequisite)
    {
        _prerequisites.RemoveAll(x => x.Id == prerequisite.Id);
        return this;
    }

    public Course AddEnrollment(Enrollment enrollment)
    {
        _enrollments.Add(enrollment);
        return this;
    }
    
    public Course RemoveEnrollment(Enrollment enrollment)
    {
        _enrollments.RemoveAll(x => x.Id == enrollment.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Course() { } // For EF + Mocking
}
