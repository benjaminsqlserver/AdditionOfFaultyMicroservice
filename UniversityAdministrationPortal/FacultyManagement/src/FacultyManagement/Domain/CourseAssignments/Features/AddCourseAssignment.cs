namespace FacultyManagement.Domain.CourseAssignments.Features;

using FacultyManagement.Domain.CourseAssignments.Services;
using FacultyManagement.Domain.CourseAssignments;
using FacultyManagement.Domain.CourseAssignments.Dtos;
using FacultyManagement.Domain.CourseAssignments.Models;
using FacultyManagement.Services;
using FacultyManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddCourseAssignment
{
    public sealed record Command(CourseAssignmentForCreationDto CourseAssignmentToAdd) : IRequest<CourseAssignmentDto>;

    public sealed class Handler(ICourseAssignmentRepository courseAssignmentRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, CourseAssignmentDto>
    {
        public async Task<CourseAssignmentDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var courseAssignmentToAdd = request.CourseAssignmentToAdd.ToCourseAssignmentForCreation();
            var courseAssignment = CourseAssignment.Create(courseAssignmentToAdd);

            await courseAssignmentRepository.Add(courseAssignment, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return courseAssignment.ToCourseAssignmentDto();
        }
    }
}