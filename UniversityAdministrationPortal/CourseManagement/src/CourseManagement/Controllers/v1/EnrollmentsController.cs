namespace CourseManagement.Controllers.v1;

using CourseManagement.Domain.Enrollments.Features;
using CourseManagement.Domain.Enrollments.Dtos;
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
[Route("api/v{v:apiVersion}/enrollments")]
[ApiVersion("1.0")]
public sealed class EnrollmentsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Enrollment record.
    /// </summary>
    [HttpPost(Name = "AddEnrollment")]
    public async Task<ActionResult<EnrollmentDto>> AddEnrollment([FromBody]EnrollmentForCreationDto enrollmentForCreation)
    {
        var command = new AddEnrollment.Command(enrollmentForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetEnrollment",
            new { enrollmentId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Enrollment by ID.
    /// </summary>
    [HttpGet("{enrollmentId:guid}", Name = "GetEnrollment")]
    public async Task<ActionResult<EnrollmentDto>> GetEnrollment(Guid enrollmentId)
    {
        var query = new GetEnrollment.Query(enrollmentId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Enrollments.
    /// </summary>
    [HttpGet(Name = "GetEnrollments")]
    public async Task<IActionResult> GetEnrollments([FromQuery] EnrollmentParametersDto enrollmentParametersDto)
    {
        var query = new GetEnrollmentList.Query(enrollmentParametersDto);
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
    /// Updates an entire existing Enrollment.
    /// </summary>
    [HttpPut("{enrollmentId:guid}", Name = "UpdateEnrollment")]
    public async Task<IActionResult> UpdateEnrollment(Guid enrollmentId, EnrollmentForUpdateDto enrollment)
    {
        var command = new UpdateEnrollment.Command(enrollmentId, enrollment);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Enrollment record.
    /// </summary>
    [HttpDelete("{enrollmentId:guid}", Name = "DeleteEnrollment")]
    public async Task<ActionResult> DeleteEnrollment(Guid enrollmentId)
    {
        var command = new DeleteEnrollment.Command(enrollmentId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
