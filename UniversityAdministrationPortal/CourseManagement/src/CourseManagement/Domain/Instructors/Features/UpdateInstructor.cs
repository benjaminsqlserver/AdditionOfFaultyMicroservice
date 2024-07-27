namespace CourseManagement.Domain.Instructors.Features;

using CourseManagement.Domain.Instructors;
using CourseManagement.Domain.Instructors.Dtos;
using CourseManagement.Domain.Instructors.Services;
using CourseManagement.Services;
using CourseManagement.Domain.Instructors.Models;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdateInstructor
{
    public sealed record Command(Guid InstructorId, InstructorForUpdateDto UpdatedInstructorData) : IRequest;

    public sealed class Handler(IInstructorRepository instructorRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var instructorToUpdate = await instructorRepository.GetById(request.InstructorId, cancellationToken: cancellationToken);
            var instructorToAdd = request.UpdatedInstructorData.ToInstructorForUpdate();
            instructorToUpdate.Update(instructorToAdd);

            instructorRepository.Update(instructorToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}