namespace FacultyManagement.Controllers.v1;

using FacultyManagement.Domain.Faculties.Features;
using FacultyManagement.Domain.Faculties.Dtos;
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
[Route("api/v{v:apiVersion}/faculties")]
[ApiVersion("1.0")]
public sealed class FacultiesController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Faculty record.
    /// </summary>
    [HttpPost(Name = "AddFaculty")]
    public async Task<ActionResult<FacultyDto>> AddFaculty([FromBody]FacultyForCreationDto facultyForCreation)
    {
        var command = new AddFaculty.Command(facultyForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetFaculty",
            new { facultyId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Faculty by ID.
    /// </summary>
    [HttpGet("{facultyId:guid}", Name = "GetFaculty")]
    public async Task<ActionResult<FacultyDto>> GetFaculty(Guid facultyId)
    {
        var query = new GetFaculty.Query(facultyId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Faculties.
    /// </summary>
    [HttpGet(Name = "GetFaculties")]
    public async Task<IActionResult> GetFaculties([FromQuery] FacultyParametersDto facultyParametersDto)
    {
        var query = new GetFacultyList.Query(facultyParametersDto);
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
    /// Updates an entire existing Faculty.
    /// </summary>
    [HttpPut("{facultyId:guid}", Name = "UpdateFaculty")]
    public async Task<IActionResult> UpdateFaculty(Guid facultyId, FacultyForUpdateDto faculty)
    {
        var command = new UpdateFaculty.Command(facultyId, faculty);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Faculty record.
    /// </summary>
    [HttpDelete("{facultyId:guid}", Name = "DeleteFaculty")]
    public async Task<ActionResult> DeleteFaculty(Guid facultyId)
    {
        var command = new DeleteFaculty.Command(facultyId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
