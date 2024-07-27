namespace CourseManagement.Domain.Students.Features;

using CourseManagement.Domain.Students.Services;
using CourseManagement.Domain.Students;
using CourseManagement.Domain.Students.Dtos;
using CourseManagement.Domain.Students.Models;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddStudent
{
    public sealed record Command(StudentForCreationDto StudentToAdd) : IRequest<StudentDto>;

    public sealed class Handler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, StudentDto>
    {
        public async Task<StudentDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var studentToAdd = request.StudentToAdd.ToStudentForCreation();
            var student = Student.Create(studentToAdd);

            await studentRepository.Add(student, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return student.ToStudentDto();
        }
    }
}