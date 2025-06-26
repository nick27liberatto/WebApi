namespace Application.Handlers
{
    using Application.Dto.Response;
    using Application.Queries;
    using AutoMapper;
    using Domain.Interfaces;
    using Domain.Models;
    using MediatR;

    public class SearchElementsHandler : IRequestHandler<SearchElementsQuery, IEnumerable<ElementResponseDto>>
    {
        private readonly IRepository<Element> _repository;
        private readonly IMapper _mapper;

        public SearchElementsHandler(IRepository<Element> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ElementResponseDto>> Handle(SearchElementsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();

            if (request.Status.HasValue)
            {
                entities = entities
                    .Where(e => e.Status == request.Status)
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
            return _mapper.Map<IEnumerable<ElementResponseDto>>(entities);
        }
    }
}
