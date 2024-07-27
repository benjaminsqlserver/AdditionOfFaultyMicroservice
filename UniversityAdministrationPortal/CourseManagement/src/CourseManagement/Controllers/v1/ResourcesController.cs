namespace CourseManagement.Controllers.v1;

using CourseManagement.Domain.Resources.Features;
using CourseManagement.Domain.Resources.Dtos;
using CourseManagement.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using Asp.Versioning;
using MediatR;

[ApiController]
[Route("api/v{v:apiVersion}/resources")]
[ApiVersion("1.0")]
public sealed class ResourcesController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Resource record.
    /// </summary>
    [HttpPost(Name = "AddResource")]
    public async Task<ActionResult<ResourceDto>> AddResource([FromBody]ResourceForCreationDto resourceForCreation)
    {
        var command = new AddResource.Command(resourceForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetResource",
            new { resourceId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Resource by ID.
    /// </summary>
    [HttpGet("{resourceId:guid}", Name = "GetResource")]
    public async Task<ActionResult<ResourceDto>> GetResource(Guid resourceId)
    {
        var query = new GetResource.Query(resourceId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Resources.
    /// </summary>
    [HttpGet(Name = "GetResources")]
    public async Task<IActionResult> GetResources([FromQuery] ResourceParametersDto resourceParametersDto)
    {
        var query = new GetResourceList.Query(resourceParametersDto);
        var queryResponse = await mediator.Send(query);

        var paginationMetadata = new
        {
            totalCount = queryResponse.TotalCount,
            pageSize = queryResponse.PageSize,
            currentPageSize = queryResponse.CurrentPageSize,
            currentStartIndex = queryResponse.CurrentStartIndex,
            currentEndIndex = queryResponse.CurrentEndIndex,
            pageNumber = queryResponse.PageNumber,
            totalPages = queryResponse.TotalPages,
            hasPrevious = queryResponse.HasPrevious,
            hasNext = queryResponse.HasNext
        };

        Response.Headers.Append("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata));

        return Ok(queryResponse);
    }


    /// <summary>
    /// Updates an entire existing Resource.
    /// </summary>
    [HttpPut("{resourceId:guid}", Name = "UpdateResource")]
    public async Task<IActionResult> UpdateResource(Guid resourceId, ResourceForUpdateDto resource)
    {
        var command = new UpdateResource.Command(resourceId, resource);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Resource record.
    /// </summary>
    [HttpDelete("{resourceId:guid}", Name = "DeleteResource")]
    public async Task<ActionResult> DeleteResource(Guid resourceId)
    {
        var command = new DeleteResource.Command(resourceId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
