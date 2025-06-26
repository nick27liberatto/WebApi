using Application.Commands;
using Application.Dto.Request;
using Application.Dto.Request.CommandDto;
using Application.Dto.Request.QueryDto;
using Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ElementController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ElementController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SearchElementsDto dto)
    {
        var command = _mapper.Map<SearchElementsQuery>(dto);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetElementByIdQuery { Id = id });
        return result is null ? NotFound() : Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateElementDto dto)
    {
        var command = _mapper.Map<CreateElementCommand>(dto);
        var result = await _mediator.Send(command);
        return CreatedAtAction(
                nameof(Get),
                new {id = result.Id },
                result
            );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateElementDto dto)
    {
        var command = _mapper.Map<UpdateElementCommand>(dto);
        command.Id = id;
        var result = await _mediator.Send(command);
        return result is null ? NotFound() : Ok(result);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _mediator.Send(new DeleteElementCommand { Id = id });
        return result is null ? NotFound() : Ok(result);

    }
}
