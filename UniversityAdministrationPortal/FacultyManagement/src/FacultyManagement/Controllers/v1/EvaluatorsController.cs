namespace FacultyManagement.Controllers.v1;

using FacultyManagement.Domain.Evaluators.Features;
using FacultyManagement.Domain.Evaluators.Dtos;
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
[Route("api/v{v:apiVersion}/evaluators")]
[ApiVersion("1.0")]
public sealed class EvaluatorsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Evaluator record.
    /// </summary>
    [HttpPost(Name = "AddEvaluator")]
    public async Task<ActionResult<EvaluatorDto>> AddEvaluator([FromBody]EvaluatorForCreationDto evaluatorForCreation)
    {
        var command = new AddEvaluator.Command(evaluatorForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetEvaluator",
            new { evaluatorId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Evaluator by ID.
    /// </summary>
    [HttpGet("{evaluatorId:guid}", Name = "GetEvaluator")]
    public async Task<ActionResult<EvaluatorDto>> GetEvaluator(Guid evaluatorId)
    {
        var query = new GetEvaluator.Query(evaluatorId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Evaluators.
    /// </summary>
    [HttpGet(Name = "GetEvaluators")]
    public async Task<IActionResult> GetEvaluators([FromQuery] EvaluatorParametersDto evaluatorParametersDto)
    {
        var query = new GetEvaluatorList.Query(evaluatorParametersDto);
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
    /// Updates an entire existing Evaluator.
    /// </summary>
    [HttpPut("{evaluatorId:guid}", Name = "UpdateEvaluator")]
    public async Task<IActionResult> UpdateEvaluator(Guid evaluatorId, EvaluatorForUpdateDto evaluator)
    {
        var command = new UpdateEvaluator.Command(evaluatorId, evaluator);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Evaluator record.
    /// </summary>
    [HttpDelete("{evaluatorId:guid}", Name = "DeleteEvaluator")]
    public async Task<ActionResult> DeleteEvaluator(Guid evaluatorId)
    {
        var command = new DeleteEvaluator.Command(evaluatorId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
