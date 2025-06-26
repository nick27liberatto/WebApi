namespace Application.Handlers
{
    using AutoMapper;
    using Commands;
    using MediatR;
    using Domain.Enums;
    using Application.Dto.Request;
    using Domain.Interfaces;
    using Domain.Models;
    using Application.Dto.Response;

    public class CreateElementHandler : IRequestHandler<CreateElementCommand, ElementResponseDto>
    {
        private readonly IRepository<Element> _repository;
        private readonly IMapper _mapper;
        public CreateElementHandler(IRepository<Element> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ElementResponseDto> Handle(CreateElementCommand request, CancellationToken cancellationToken)
        {
            var element = _mapper.Map<Element>(request);
            if (request.Status.HasValue && !Enum.IsDefined(typeof(ElementEnum), request.Status.Value))
                throw new ArgumentOutOfRangeException(nameof(request.Status), "Invalid value for StaticStatus");
            await _repository.AddAsync(element);
            return _mapper.Map<ElementResponseDto>(element);
        }
    }
}
