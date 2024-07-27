namespace CourseManagement.Domain.LectureHalls.Dtos;

using Destructurama.Attributed;

public sealed record LectureHallDto
{
    public Guid Id { get; set; }
    public string RoomNumber { get; set; }
    public int Capacity { get; set; }

}
