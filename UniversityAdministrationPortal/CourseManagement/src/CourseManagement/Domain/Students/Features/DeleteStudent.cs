namespace CourseManagement.Domain.Students.Features;

using CourseManagement.Domain.Students.Services;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using MediatR;

public static class DeleteStudent
{
    public sealed record Command(Guid StudentId) : IRequest;

    public sealed class Handler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await studentRepository.GetById(request.StudentId, cancellationToken: cancellationToken);
            studentRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}