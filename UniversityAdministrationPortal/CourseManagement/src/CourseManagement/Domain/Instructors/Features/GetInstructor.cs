namespace CourseManagement.Domain.Instructors.Features;

using CourseManagement.Domain.Instructors.Dtos;
using CourseManagement.Domain.Instructors.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class GetInstructor
{
    public sealed record Query(Guid InstructorId) : IRequest<InstructorDto>;

    public sealed class Handler(IInstructorRepository instructorRepository)
        : IRequestHandler<Query, InstructorDto>
    {
        public async Task<InstructorDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await instructorRepository.GetById(request.InstructorId, cancellationToken: cancellationToken);
            return result.ToInstructorDto();
        }
    }
}