using AutoMapper;
using Domain.Commands;
using Domain.Dto.Request;
using Domain.Dto.Response;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Domain.Handlers
{
    public class UpdateElementHandler : IRequestHandler<UpdateElementCommand, EntityRequestDto>
    {
        private readonly IRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public UpdateElementHandler(IRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<EntityRequestDto> Handle(UpdateElementCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null) return null;
            
            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);
            return _mapper.Map<EntityRequestDto>(entity);
        }
    }
}
