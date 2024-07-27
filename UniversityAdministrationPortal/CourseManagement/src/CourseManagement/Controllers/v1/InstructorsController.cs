namespace CourseManagement.Controllers.v1;

using CourseManagement.Domain.Instructors.Features;
using CourseManagement.Domain.Instructors.Dtos;
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
[Route("api/v{v:apiVersion}/instructors")]
[ApiVersion("1.0")]
public sealed class InstructorsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Instructor record.
    /// </summary>
    [HttpPost(Name = "AddInstructor")]
    public async Task<ActionResult<InstructorDto>> AddInstructor([FromBody]InstructorForCreationDto instructorForCreation)
    {
        var command = new AddInstructor.Command(instructorForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetInstructor",
            new { instructorId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Instructor by ID.
    /// </summary>
    [HttpGet("{instructorId:guid}", Name = "GetInstructor")]
    public async Task<ActionResult<InstructorDto>> GetInstructor(Guid instructorId)
    {
        var query = new GetInstructor.Query(instructorId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Instructors.
    /// </summary>
    [HttpGet(Name = "GetInstructors")]
    public async Task<IActionResult> GetInstructors([FromQuery] InstructorParametersDto instructorParametersDto)
    {
        var query = new GetInstructorList.Query(instructorParametersDto);
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
    /// Updates an entire existing Instructor.
    /// </summary>
    [HttpPut("{instructorId:guid}", Name = "UpdateInstructor")]
    public async Task<IActionResult> UpdateInstructor(Guid instructorId, InstructorForUpdateDto instructor)
    {
        var command = new UpdateInstructor.Command(instructorId, instructor);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Instructor record.
    /// </summary>
    [HttpDelete("{instructorId:guid}", Name = "DeleteInstructor")]
    public async Task<ActionResult> DeleteInstructor(Guid instructorId)
    {
        var command = new DeleteInstructor.Command(instructorId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
