namespace CourseManagement.Domain.LectureHalls;

using System.ComponentModel.DataAnnotations;
using CourseManagement.Domain.Schedules;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using CourseManagement.Exceptions;
using CourseManagement.Domain.LectureHalls.Models;
using CourseManagement.Domain.LectureHalls.DomainEvents;
using CourseManagement.Domain.Schedules;
using CourseManagement.Domain.Schedules.Models;


public class LectureHall : BaseEntity
{
    public string RoomNumber { get; private set; }

    public int Capacity { get; private set; }

    private readonly List<Schedule> _schedules = new();
    public IReadOnlyCollection<Schedule> Schedules => _schedules.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static LectureHall Create(LectureHallForCreation lectureHallForCreation)
    {
        var newLectureHall = new LectureHall();

        newLectureHall.RoomNumber = lectureHallForCreation.RoomNumber;
        newLectureHall.Capacity = lectureHallForCreation.Capacity;

        newLectureHall.QueueDomainEvent(new LectureHallCreated(){ LectureHall = newLectureHall });
        
        return newLectureHall;
    }

    public LectureHall Update(LectureHallForUpdate lectureHallForUpdate)
    {
        RoomNumber = lectureHallForUpdate.RoomNumber;
        Capacity = lectureHallForUpdate.Capacity;

        QueueDomainEvent(new LectureHallUpdated(){ Id = Id });
        return this;
    }

    public LectureHall AddSchedule(Schedule schedule)
    {
        _schedules.Add(schedule);
        return this;
    }
    
    public LectureHall RemoveSchedule(Schedule schedule)
    {
        _schedules.RemoveAll(x => x.Id == schedule.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected LectureHall() { } // For EF + Mocking
}
