using Domain.Models;
using Domain.Interfaces;
using AutoMapper;
using MediatR;
using Domain.Queries;
using Domain.Dto.Response;

namespace Domain.Handlers
{
    public class GetElementsHandler : IRequestHandler<GetElementsQuery, IEnumerable<EntityResponseDto>>
    {
        private readonly IRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GetElementsHandler(IRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EntityResponseDto>> Handle(GetElementsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();

            if (request.Status.HasValue)
            {
                entities = entities
                    .Where(e => e.StaticStatus == request.Status)
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                entities = entities
                    .Where(e =>
                        (!string.IsNullOrEmpty(e.Name) && e.Name.Contains(request.Search, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(e.Text) && e.Text.Contains(request.Search, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }
            return _mapper.Map<IEnumerable<EntityResponseDto>>(entities);
        }
    }
}
