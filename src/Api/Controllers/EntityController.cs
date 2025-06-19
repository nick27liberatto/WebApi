using Domain.Commands;
using Domain.Models;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EntityController : ControllerBase
{
    private readonly IMediator _mediator;

    public EntityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetElementsQuery request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] long id)
    {
        var result = await _mediator.Send(new GetElementByIdQuery { Id = id });
        if (result == null) return NotFound(result); else return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateElementCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { result }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateElementCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        if (result == null) return NotFound(result); else return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var result = await _mediator.Send(new DeleteElementCommand { Id = id });
        if (result == null) return NotFound(result); else return Ok(result);
    }
}
