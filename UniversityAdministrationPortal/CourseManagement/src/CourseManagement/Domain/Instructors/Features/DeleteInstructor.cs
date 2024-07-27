namespace CourseManagement.Domain.Instructors.Features;

using CourseManagement.Domain.Instructors.Services;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using MediatR;

public static class DeleteInstructor
{
    public sealed record Command(Guid InstructorId) : IRequest;

    public sealed class Handler(IInstructorRepository instructorRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await instructorRepository.GetById(request.InstructorId, cancellationToken: cancellationToken);
            instructorRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}