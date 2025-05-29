using AutoMapper;
using Domain.Commands;
using Domain.Dto.Response;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Domain.Handlers
{
    public class DeleteElementHandler : IRequestHandler<DeleteElementCommand, EntityResponseDto>
    {
        private readonly IRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public DeleteElementHandler(IRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EntityResponseDto> Handle(DeleteElementCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null) return null;

            await _repository.DeleteAsync(request.Id);
            return _mapper.Map<EntityResponseDto>(entity);
        }
    }
}
