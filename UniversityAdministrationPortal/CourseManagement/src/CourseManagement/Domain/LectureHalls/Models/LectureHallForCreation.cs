namespace CourseManagement.Domain.LectureHalls.Models;

using Destructurama.Attributed;

public sealed record LectureHallForCreation
{
    public string RoomNumber { get; set; }
    public int Capacity { get; set; }

}
