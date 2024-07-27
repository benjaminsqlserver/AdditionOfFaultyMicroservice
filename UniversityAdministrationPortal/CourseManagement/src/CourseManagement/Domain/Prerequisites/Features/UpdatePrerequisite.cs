namespace CourseManagement.Domain.Prerequisites.Features;

using CourseManagement.Domain.Prerequisites;
using CourseManagement.Domain.Prerequisites.Dtos;
using CourseManagement.Domain.Prerequisites.Services;
using CourseManagement.Services;
using CourseManagement.Domain.Prerequisites.Models;
using CourseManagement.Exceptions;
using Mappings;
using MediatR;

public static class UpdatePrerequisite
{
    public sealed record Command(Guid PrerequisiteId, PrerequisiteForUpdateDto UpdatedPrerequisiteData) : IRequest;

    public sealed class Handler(IPrerequisiteRepository prerequisiteRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var prerequisiteToUpdate = await prerequisiteRepository.GetById(request.PrerequisiteId, cancellationToken: cancellationToken);
            var prerequisiteToAdd = request.UpdatedPrerequisiteData.ToPrerequisiteForUpdate();
            prerequisiteToUpdate.Update(prerequisiteToAdd);

            prerequisiteRepository.Update(prerequisiteToUpdate);
            await unitOfWork.CommitChanges(cancellationToken);
        }
    }
}