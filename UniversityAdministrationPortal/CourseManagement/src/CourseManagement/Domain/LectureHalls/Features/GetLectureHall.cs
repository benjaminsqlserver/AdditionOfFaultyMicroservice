namespace CourseManagement.Domain.LectureHalls.Features;

using CourseManagement.Domain.LectureHalls.Dtos;
using CourseManagement.Domain.LectureHalls.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetLectureHall
{
    public sealed record Query(Guid LectureHallId) : IRequest<LectureHallDto>;

    public sealed class Handler(ILectureHallRepository lectureHallRepository)
        : IRequestHandler<Query, LectureHallDto>
    {
        public async Task<LectureHallDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await lectureHallRepository.GetById(request.LectureHallId, cancellationToken: cancellationToken);
            return result.ToLectureHallDto();
        }
    }
}