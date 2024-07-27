namespace CourseManagement.Controllers.v1;

using CourseManagement.Domain.Schedules.Features;
using CourseManagement.Domain.Schedules.Dtos;
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
[Route("api/v{v:apiVersion}/schedules")]
[ApiVersion("1.0")]
public sealed class SchedulesController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Schedule record.
    /// </summary>
    [HttpPost(Name = "AddSchedule")]
    public async Task<ActionResult<ScheduleDto>> AddSchedule([FromBody]ScheduleForCreationDto scheduleForCreation)
    {
        var command = new AddSchedule.Command(scheduleForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetSchedule",
            new { scheduleId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Schedule by ID.
    /// </summary>
    [HttpGet("{scheduleId:guid}", Name = "GetSchedule")]
    public async Task<ActionResult<ScheduleDto>> GetSchedule(Guid scheduleId)
    {
        var query = new GetSchedule.Query(scheduleId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Schedules.
    /// </summary>
    [HttpGet(Name = "GetSchedules")]
    public async Task<IActionResult> GetSchedules([FromQuery] ScheduleParametersDto scheduleParametersDto)
    {
        var query = new GetScheduleList.Query(scheduleParametersDto);
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
    /// Updates an entire existing Schedule.
    /// </summary>
    [HttpPut("{scheduleId:guid}", Name = "UpdateSchedule")]
    public async Task<IActionResult> UpdateSchedule(Guid scheduleId, ScheduleForUpdateDto schedule)
    {
        var command = new UpdateSchedule.Command(scheduleId, schedule);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Schedule record.
    /// </summary>
    [HttpDelete("{scheduleId:guid}", Name = "DeleteSchedule")]
    public async Task<ActionResult> DeleteSchedule(Guid scheduleId)
    {
        var command = new DeleteSchedule.Command(scheduleId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
