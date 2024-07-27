namespace CourseManagement.Controllers.v1;

using CourseManagement.Domain.Courses.Features;
using CourseManagement.Domain.Courses.Dtos;
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
[Route("api/v{v:apiVersion}/courses")]
[ApiVersion("1.0")]
public sealed class CoursesController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Course record.
    /// </summary>
    [HttpPost(Name = "AddCourse")]
    public async Task<ActionResult<CourseDto>> AddCourse([FromBody]CourseForCreationDto courseForCreation)
    {
        var command = new AddCourse.Command(courseForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetCourse",
            new { courseId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Course by ID.
    /// </summary>
    [HttpGet("{courseId:guid}", Name = "GetCourse")]
    public async Task<ActionResult<CourseDto>> GetCourse(Guid courseId)
    {
        var query = new GetCourse.Query(courseId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Courses.
    /// </summary>
    [HttpGet(Name = "GetCourses")]
    public async Task<IActionResult> GetCourses([FromQuery] CourseParametersDto courseParametersDto)
    {
        var query = new GetCourseList.Query(courseParametersDto);
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
    /// Updates an entire existing Course.
    /// </summary>
    [HttpPut("{courseId:guid}", Name = "UpdateCourse")]
    public async Task<IActionResult> UpdateCourse(Guid courseId, CourseForUpdateDto course)
    {
        var command = new UpdateCourse.Command(courseId, course);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Course record.
    /// </summary>
    [HttpDelete("{courseId:guid}", Name = "DeleteCourse")]
    public async Task<ActionResult> DeleteCourse(Guid courseId)
    {
        var command = new DeleteCourse.Command(courseId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
