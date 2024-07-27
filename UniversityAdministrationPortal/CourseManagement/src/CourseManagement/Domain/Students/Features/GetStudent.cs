namespace CourseManagement.Domain.Students.Features;

using CourseManagement.Domain.Students.Dtos;
using CourseManagement.Domain.Students.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetStudent
{
    public sealed record Query(Guid StudentId) : IRequest<StudentDto>;

    public sealed class Handler(IStudentRepository studentRepository)
        : IRequestHandler<Query, StudentDto>
    {
        public async Task<StudentDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await studentRepository.GetById(request.StudentId, cancellationToken: cancellationToken);
            return result.ToStudentDto();
        }
    }
}