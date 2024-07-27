namespace CourseManagement.Controllers.v1;

using CourseManagement.Domain.LectureHalls.Features;
using CourseManagement.Domain.LectureHalls.Dtos;
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
[Route("api/v{v:apiVersion}/lecturehalls")]
[ApiVersion("1.0")]
public sealed class LectureHallsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new LectureHall record.
    /// </summary>
    [HttpPost(Name = "AddLectureHall")]
    public async Task<ActionResult<LectureHallDto>> AddLectureHall([FromBody]LectureHallForCreationDto lectureHallForCreation)
    {
        var command = new AddLectureHall.Command(lectureHallForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetLectureHall",
            new { lectureHallId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single LectureHall by ID.
    /// </summary>
    [HttpGet("{lectureHallId:guid}", Name = "GetLectureHall")]
    public async Task<ActionResult<LectureHallDto>> GetLectureHall(Guid lectureHallId)
    {
        var query = new GetLectureHall.Query(lectureHallId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all LectureHalls.
    /// </summary>
    [HttpGet(Name = "GetLectureHalls")]
    public async Task<IActionResult> GetLectureHalls([FromQuery] LectureHallParametersDto lectureHallParametersDto)
    {
        var query = new GetLectureHallList.Query(lectureHallParametersDto);
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
    /// Updates an entire existing LectureHall.
    /// </summary>
    [HttpPut("{lectureHallId:guid}", Name = "UpdateLectureHall")]
    public async Task<IActionResult> UpdateLectureHall(Guid lectureHallId, LectureHallForUpdateDto lectureHall)
    {
        var command = new UpdateLectureHall.Command(lectureHallId, lectureHall);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing LectureHall record.
    /// </summary>
    [HttpDelete("{lectureHallId:guid}", Name = "DeleteLectureHall")]
    public async Task<ActionResult> DeleteLectureHall(Guid lectureHallId)
    {
        var command = new DeleteLectureHall.Command(lectureHallId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
