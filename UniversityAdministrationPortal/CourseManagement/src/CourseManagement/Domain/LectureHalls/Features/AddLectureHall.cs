namespace CourseManagement.Domain.LectureHalls.Features;

using CourseManagement.Domain.LectureHalls.Services;
using CourseManagement.Domain.LectureHalls;
using CourseManagement.Domain.LectureHalls.Dtos;
using CourseManagement.Domain.LectureHalls.Models;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddLectureHall
{
    public sealed record Command(LectureHallForCreationDto LectureHallToAdd) : IRequest<LectureHallDto>;

    public sealed class Handler(ILectureHallRepository lectureHallRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, LectureHallDto>
    {
        public async Task<LectureHallDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var lectureHallToAdd = request.LectureHallToAdd.ToLectureHallForCreation();
            var lectureHall = LectureHall.Create(lectureHallToAdd);

            await lectureHallRepository.Add(lectureHall, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return lectureHall.ToLectureHallDto();
        }
    }
}