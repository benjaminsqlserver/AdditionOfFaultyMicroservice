namespace CourseManagement.Domain.Students.Features;

using CourseManagement.Domain.Students;
using CourseManagement.Domain.Students.Dtos;
using CourseManagement.Domain.Students.Services;
using CourseManagement.Services;
using CourseManagement.Domain.Students.Models;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateStudent
{
    public sealed record Command(Guid StudentId, StudentForUpdateDto UpdatedStudentData) : IRequest;

    public sealed class Handler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var studentToUpdate = await studentRepository.GetById(request.StudentId, cancellationToken: cancellationToken);
            var studentToAdd = request.UpdatedStudentData.ToStudentForUpdate();
            studentToUpdate.Update(studentToAdd);

            studentRepository.Update(studentToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}