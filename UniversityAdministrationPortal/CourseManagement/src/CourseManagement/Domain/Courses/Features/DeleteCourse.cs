namespace CourseManagement.Domain.Courses.Features;

using CourseManagement.Domain.Courses.Services;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using MediatR;

public static class DeleteCourse
{
    public sealed record Command(Guid CourseId) : IRequest;

    public sealed class Handler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await courseRepository.GetById(request.CourseId, cancellationToken: cancellationToken);
            courseRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}