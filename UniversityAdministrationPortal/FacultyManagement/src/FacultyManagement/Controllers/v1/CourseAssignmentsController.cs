namespace FacultyManagement.Controllers.v1;

using FacultyManagement.Domain.CourseAssignments.Features;
using FacultyManagement.Domain.CourseAssignments.Dtos;
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
[Route("api/v{v:apiVersion}/courseassignments")]
[ApiVersion("1.0")]
public sealed class CourseAssignmentsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new CourseAssignment record.
    /// </summary>
    [HttpPost(Name = "AddCourseAssignment")]
    public async Task<ActionResult<CourseAssignmentDto>> AddCourseAssignment([FromBody]CourseAssignmentForCreationDto courseAssignmentForCreation)
    {
        var command = new AddCourseAssignment.Command(courseAssignmentForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetCourseAssignment",
            new { courseAssignmentId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single CourseAssignment by ID.
    /// </summary>
    [HttpGet("{courseAssignmentId:guid}", Name = "GetCourseAssignment")]
    public async Task<ActionResult<CourseAssignmentDto>> GetCourseAssignment(Guid courseAssignmentId)
    {
        var query = new GetCourseAssignment.Query(courseAssignmentId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all CourseAssignments.
    /// </summary>
    [HttpGet(Name = "GetCourseAssignments")]
    public async Task<IActionResult> GetCourseAssignments([FromQuery] CourseAssignmentParametersDto courseAssignmentParametersDto)
    {
        var query = new GetCourseAssignmentList.Query(courseAssignmentParametersDto);
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
    /// Updates an entire existing CourseAssignment.
    /// </summary>
    [HttpPut("{courseAssignmentId:guid}", Name = "UpdateCourseAssignment")]
    public async Task<IActionResult> UpdateCourseAssignment(Guid courseAssignmentId, CourseAssignmentForUpdateDto courseAssignment)
    {
        var command = new UpdateCourseAssignment.Command(courseAssignmentId, courseAssignment);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing CourseAssignment record.
    /// </summary>
    [HttpDelete("{courseAssignmentId:guid}", Name = "DeleteCourseAssignment")]
    public async Task<ActionResult> DeleteCourseAssignment(Guid courseAssignmentId)
    {
        var command = new DeleteCourseAssignment.Command(courseAssignmentId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
