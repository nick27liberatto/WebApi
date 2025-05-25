using Domain.Commands;
using Domain.Dto.Request;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CrudController : ControllerBase
{
    private readonly IMediator _mediator;

    public CrudController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll(GetElementsQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(long Id, GetElementByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request.Id = Id);
        return Ok(result);
    }
    [HttpPost]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(CreateElementCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { result }, command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(long Id, UpdateElementCommand command, CancellationToken cancellationToken)
    {
        command.Id = Id;
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long Id, DeleteElementCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command.Id = Id);
        return Ok(result);
    }
}
