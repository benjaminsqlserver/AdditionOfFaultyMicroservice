namespace CourseManagement.Domain.Instructors.Dtos;

using Destructurama.Attributed;

public sealed record InstructorForUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

}
