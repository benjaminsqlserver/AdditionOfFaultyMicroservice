namespace CourseManagement.Domain.LectureHalls.Dtos;

using Destructurama.Attributed;

public sealed record LectureHallForCreationDto
{
    public string RoomNumber { get; set; }
    public int Capacity { get; set; }

}
