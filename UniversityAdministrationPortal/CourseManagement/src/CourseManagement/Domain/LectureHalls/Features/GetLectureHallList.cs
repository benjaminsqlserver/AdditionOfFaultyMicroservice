namespace CourseManagement.Domain.LectureHalls.Features;

using CourseManagement.Domain.LectureHalls.Dtos;
using CourseManagement.Domain.LectureHalls.Services;
using CourseManagement.Exceptions;
using CourseManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetLectureHallList
{
    public sealed record Query(LectureHallParametersDto QueryParameters) : IRequest<PagedList<LectureHallDto>>;

    public sealed class Handler(ILectureHallRepository lectureHallRepository)
        : IRequestHandler<Query, PagedList<LectureHallDto>>
    {
        public async Task<PagedList<LectureHallDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = lectureHallRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToLectureHallDtoQueryable();

            return await PagedList<LectureHallDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}