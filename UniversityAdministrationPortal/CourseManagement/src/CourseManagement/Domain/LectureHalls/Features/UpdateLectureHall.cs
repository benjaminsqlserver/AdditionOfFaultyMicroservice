namespace CourseManagement.Domain.LectureHalls.Features;

using CourseManagement.Domain.LectureHalls;
using CourseManagement.Domain.LectureHalls.Dtos;
using CourseManagement.Domain.LectureHalls.Services;
using CourseManagement.Services;
using CourseManagement.Domain.LectureHalls.Models;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateLectureHall
{
    public sealed record Command(Guid LectureHallId, LectureHallForUpdateDto UpdatedLectureHallData) : IRequest;

    public sealed class Handler(ILectureHallRepository lectureHallRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var lectureHallToUpdate = await lectureHallRepository.GetById(request.LectureHallId, cancellationToken: cancellationToken);
            var lectureHallToAdd = request.UpdatedLectureHallData.ToLectureHallForUpdate();
            lectureHallToUpdate.Update(lectureHallToAdd);

            lectureHallRepository.Update(lectureHallToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}