namespace CourseManagement.Domain.Prerequisites.Features;

using CourseManagement.Domain.Prerequisites.Services;
using CourseManagement.Domain.Prerequisites;
using CourseManagement.Domain.Prerequisites.Dtos;
using CourseManagement.Domain.Prerequisites.Models;
using CourseManagement.Services;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class AddPrerequisite
{
    public sealed record Command(PrerequisiteForCreationDto PrerequisiteToAdd) : IRequest<PrerequisiteDto>;

    public sealed class Handler(IPrerequisiteRepository prerequisiteRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command, PrerequisiteDto>
    {
        public async Task<PrerequisiteDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var prerequisiteToAdd = request.PrerequisiteToAdd.ToPrerequisiteForCreation();
            var prerequisite = Prerequisite.Create(prerequisiteToAdd);

            await prerequisiteRepository.Add(prerequisite, cancellationToken);
            await unitOfWork.CommitChanges(cancellationToken);

            return prerequisite.ToPrerequisiteDto();
        }
    }
}