namespace CourseManagement.Domain.LectureHalls.Features;

using CourseManagement.Domain.LectureHalls.Services;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using MediatR;

public static class DeleteLectureHall
{
    public sealed record Command(Guid LectureHallId) : IRequest;

    public sealed class Handler(ILectureHallRepository lectureHallRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await lectureHallRepository.GetById(request.LectureHallId, cancellationToken: cancellationToken);
            lectureHallRepository.Remove(recordToDelete);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}