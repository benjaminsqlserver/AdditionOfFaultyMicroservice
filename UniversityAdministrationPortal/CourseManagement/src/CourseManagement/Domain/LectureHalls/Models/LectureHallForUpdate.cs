namespace CourseManagement.Domain.LectureHalls.Models;

using Destructurama.Attributed;

public sealed record LectureHallForUpdate
{
    public string RoomNumber { get; set; }
    public int Capacity { get; set; }

}
