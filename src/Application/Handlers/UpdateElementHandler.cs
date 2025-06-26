namespace Application.Handlers
{
    using Application.Commands;
    using Application.Dto.Request;
    using Application.Dto.Response;
    using AutoMapper;
    using Domain.Interfaces;
    using Domain.Models;
    using MediatR;

    public class UpdateElementHandler : IRequestHandler<UpdateElementCommand, ElementResponseDto>
    {
        private readonly IRepository<Element> _repository;
        private readonly IMapper _mapper;

        public UpdateElementHandler(IRepository<Element> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ElementResponseDto> Handle(UpdateElementCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null) return null;
            
            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);
            return _mapper.Map<ElementResponseDto>(entity);
        }
    }
}
