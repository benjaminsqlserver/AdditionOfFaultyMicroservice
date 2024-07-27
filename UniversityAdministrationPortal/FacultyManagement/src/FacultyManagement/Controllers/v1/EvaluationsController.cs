namespace FacultyManagement.Controllers.v1;

using FacultyManagement.Domain.Evaluations.Features;
using FacultyManagement.Domain.Evaluations.Dtos;
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
[Route("api/v{v:apiVersion}/evaluations")]
[ApiVersion("1.0")]
public sealed class EvaluationsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Evaluation record.
    /// </summary>
    [HttpPost(Name = "AddEvaluation")]
    public async Task<ActionResult<EvaluationDto>> AddEvaluation([FromBody]EvaluationForCreationDto evaluationForCreation)
    {
        var command = new AddEvaluation.Command(evaluationForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetEvaluation",
            new { evaluationId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Evaluation by ID.
    /// </summary>
    [HttpGet("{evaluationId:guid}", Name = "GetEvaluation")]
    public async Task<ActionResult<EvaluationDto>> GetEvaluation(Guid evaluationId)
    {
        var query = new GetEvaluation.Query(evaluationId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Evaluations.
    /// </summary>
    [HttpGet(Name = "GetEvaluations")]
    public async Task<IActionResult> GetEvaluations([FromQuery] EvaluationParametersDto evaluationParametersDto)
    {
        var query = new GetEvaluationList.Query(evaluationParametersDto);
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
    /// Updates an entire existing Evaluation.
    /// </summary>
    [HttpPut("{evaluationId:guid}", Name = "UpdateEvaluation")]
    public async Task<IActionResult> UpdateEvaluation(Guid evaluationId, EvaluationForUpdateDto evaluation)
    {
        var command = new UpdateEvaluation.Command(evaluationId, evaluation);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Evaluation record.
    /// </summary>
    [HttpDelete("{evaluationId:guid}", Name = "DeleteEvaluation")]
    public async Task<ActionResult> DeleteEvaluation(Guid evaluationId)
    {
        var command = new DeleteEvaluation.Command(evaluationId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
