namespace CourseManagement.Domain.Instructors.Features;

using CourseManagement.Domain.Instructors.Services;
using CourseManagement.Domain.Instructors;
using CourseManagement.Domain.Instructors.Dtos;
using CourseManagement.Domain.Instructors.Models;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddInstructor
{
    public sealed record Command(InstructorForCreationDto InstructorToAdd) : IRequest<InstructorDto>;

    public sealed class Handler(IInstructorRepository instructorRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, InstructorDto>
    {
        public async Task<InstructorDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var instructorToAdd = request.InstructorToAdd.ToInstructorForCreation();
            var instructor = Instructor.Create(instructorToAdd);

            await instructorRepository.Add(instructor, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return instructor.ToInstructorDto();
        }
    }
}