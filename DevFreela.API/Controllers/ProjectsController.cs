using DevFreela.Application.Commands.Project.Complete;
using DevFreela.Application.Commands.Project.Create;
using DevFreela.Application.Commands.Project.Delete;
using DevFreela.Application.Commands.Project.InsertComment;
using DevFreela.Application.Commands.Project.Start;
using DevFreela.Application.Commands.Project.Update;
using DevFreela.Application.Queries.Project.GetAll;
using DevFreela.Application.Queries.Project.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var query = new GetAllQuery();

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetByIdQuery(id);

        var result = await _mediator.Send(query, cancellationToken);

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProjectCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateProjectCommand command, CancellationToken cancellationToken)
    {
        command.Id = id;
        var result = await _mediator.Send(command, cancellationToken);

        if (!result.IsSuccess)
            return NotFound(result);

        return NoContent();
    }       

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken) 
    {
        var result = await _mediator.Send(new DeleteProjectCommand(id), cancellationToken);

        if (!result.IsSuccess)
            return NotFound(result);

        return NoContent();
    }

    [HttpPut("{id}/start")]
    public async Task<IActionResult> Start(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new StartProjectCommand(id), cancellationToken);

        if (!result.IsSuccess)
            return NotFound(result);

        return NoContent();
    }

    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CompleteProjectCommand(id), cancellationToken);

        if (!result.IsSuccess)
            return NotFound(result);

        return NoContent();
    }

    [HttpPost("{id}/comments")]
    public async Task<IActionResult> PostComment(int id, InsertCommentProjectCommand command, CancellationToken cancellationToken)
    {
        command.IdProject = id;
        var result = await _mediator.Send(command, cancellationToken);

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok();
    }
}
