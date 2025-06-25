namespace Application.Handlers
{
    using Application.Dto.Response;
    using Application.Queries;
    using AutoMapper;
    using Domain.Interfaces;
    using Domain.Models;
    using MediatR;

    public class GetElementByIdHandler : IRequestHandler<GetElementByIdQuery, ElementResponseDto>
    {
        private readonly IRepository<Element> _repository;
        private readonly IMapper _mapper;

        public GetElementByIdHandler(IRepository<Element> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ElementResponseDto> Handle(GetElementByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null) return null;
            
            return _mapper.Map<ElementResponseDto>(entity);
        }
    }
}
