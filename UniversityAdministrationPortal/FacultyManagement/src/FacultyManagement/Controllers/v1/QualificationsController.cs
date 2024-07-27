namespace FacultyManagement.Controllers.v1;

using FacultyManagement.Domain.Qualifications.Features;
using FacultyManagement.Domain.Qualifications.Dtos;
using FacultyManagement.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using Asp.Versioning;
using MediatR;

[ApiController]
[Route("api/v{v:apiVersion}/qualifications")]
[ApiVersion("1.0")]
public sealed class QualificationsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Qualification record.
    /// </summary>
    [HttpPost(Name = "AddQualification")]
    public async Task<ActionResult<QualificationDto>> AddQualification([FromBody]QualificationForCreationDto qualificationForCreation)
    {
        var command = new AddQualification.Command(qualificationForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetQualification",
            new { qualificationId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Qualification by ID.
    /// </summary>
    [HttpGet("{qualificationId:guid}", Name = "GetQualification")]
    public async Task<ActionResult<QualificationDto>> GetQualification(Guid qualificationId)
    {
        var query = new GetQualification.Query(qualificationId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Qualifications.
    /// </summary>
    [HttpGet(Name = "GetQualifications")]
    public async Task<IActionResult> GetQualifications([FromQuery] QualificationParametersDto qualificationParametersDto)
    {
        var query = new GetQualificationList.Query(qualificationParametersDto);
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
    /// Updates an entire existing Qualification.
    /// </summary>
    [HttpPut("{qualificationId:guid}", Name = "UpdateQualification")]
    public async Task<IActionResult> UpdateQualification(Guid qualificationId, QualificationForUpdateDto qualification)
    {
        var command = new UpdateQualification.Command(qualificationId, qualification);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Qualification record.
    /// </summary>
    [HttpDelete("{qualificationId:guid}", Name = "DeleteQualification")]
    public async Task<ActionResult> DeleteQualification(Guid qualificationId)
    {
        var command = new DeleteQualification.Command(qualificationId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
