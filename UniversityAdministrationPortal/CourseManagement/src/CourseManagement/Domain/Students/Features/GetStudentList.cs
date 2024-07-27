namespace CourseManagement.Domain.Students.Features;

using CourseManagement.Domain.Students.Dtos;
using CourseManagement.Domain.Students.Services;
using CourseManagement.Exceptions;
using CourseManagement.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetStudentList
{
    public sealed record Query(StudentParametersDto QueryParameters) : IRequest<PagedList<StudentDto>>;

    public sealed class Handler(IStudentRepository studentRepository)
        : IRequestHandler<Query, PagedList<StudentDto>>
    {
        public async Task<PagedList<StudentDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = studentRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToStudentDtoQueryable();

            return await PagedList<StudentDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}