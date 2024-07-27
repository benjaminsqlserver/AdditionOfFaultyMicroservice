namespace CourseManagement.Controllers.v1;

using CourseManagement.Domain.Prerequisites.Features;
using CourseManagement.Domain.Prerequisites.Dtos;
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
[Route("api/v{v:apiVersion}/prerequisites")]
[ApiVersion("1.0")]
public sealed class PrerequisitesController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Prerequisite record.
    /// </summary>
    [HttpPost(Name = "AddPrerequisite")]
    public async Task<ActionResult<PrerequisiteDto>> AddPrerequisite([FromBody]PrerequisiteForCreationDto prerequisiteForCreation)
    {
        var command = new AddPrerequisite.Command(prerequisiteForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetPrerequisite",
            new { prerequisiteId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Prerequisite by ID.
    /// </summary>
    [HttpGet("{prerequisiteId:guid}", Name = "GetPrerequisite")]
    public async Task<ActionResult<PrerequisiteDto>> GetPrerequisite(Guid prerequisiteId)
    {
        var query = new GetPrerequisite.Query(prerequisiteId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Prerequisites.
    /// </summary>
    [HttpGet(Name = "GetPrerequisites")]
    public async Task<IActionResult> GetPrerequisites([FromQuery] PrerequisiteParametersDto prerequisiteParametersDto)
    {
        var query = new GetPrerequisiteList.Query(prerequisiteParametersDto);
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
    /// Updates an entire existing Prerequisite.
    /// </summary>
    [HttpPut("{prerequisiteId:guid}", Name = "UpdatePrerequisite")]
    public async Task<IActionResult> UpdatePrerequisite(Guid prerequisiteId, PrerequisiteForUpdateDto prerequisite)
    {
        var command = new UpdatePrerequisite.Command(prerequisiteId, prerequisite);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Prerequisite record.
    /// </summary>
    [HttpDelete("{prerequisiteId:guid}", Name = "DeletePrerequisite")]
    public async Task<ActionResult> DeletePrerequisite(Guid prerequisiteId)
    {
        var command = new DeletePrerequisite.Command(prerequisiteId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
