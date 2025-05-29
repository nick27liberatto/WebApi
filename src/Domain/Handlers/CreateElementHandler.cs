namespace Domain.Handlers
{
    using AutoMapper;
    using Commands;
    using Interfaces;
    using Models;
    using MediatR;
    using Domain.Dto.Request;
    using Domain.Enums;

    public class CreateElementHandler : IRequestHandler<CreateElementCommand, EntityRequestDto>
    {
        private readonly IRepository<Entity> _repository;
        private readonly IMapper _mapper;
        public CreateElementHandler(IRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<EntityRequestDto> Handle(CreateElementCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Entity>(request);
            if (request.StaticStatus.HasValue && !Enum.IsDefined(typeof(EntityEnum), request.StaticStatus.Value))
                throw new ArgumentOutOfRangeException(nameof(request.StaticStatus), "Invalid value for StaticStatus");
            await _repository.AddAsync(entity);
            return _mapper.Map<EntityRequestDto>(entity);
        }
    }
}
