using AutoMapper;
using Domain.Dto.Response;
using Domain.Interfaces;
using Domain.Models;
using Domain.Queries;
using MediatR;

namespace Domain.Handlers
{
    public class GetElementByIdHandler : IRequestHandler<GetElementByIdQuery, EntityResponseDto>
    {
        private readonly IRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GetElementByIdHandler(IRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<EntityResponseDto> Handle(GetElementByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null) return null;
            
            return _mapper.Map<EntityResponseDto>(entity);
        }
    }
}
