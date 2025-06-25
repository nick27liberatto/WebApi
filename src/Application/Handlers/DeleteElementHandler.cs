namespace Application.Handlers
{
    using Application.Commands;
    using Application.Dto.Response;
    using AutoMapper;
    using Domain.Interfaces;
    using Domain.Models;
    using MediatR;

    public class DeleteElementHandler : IRequestHandler<DeleteElementCommand, ElementResponseDto>
    {
        private readonly IRepository<Element> _repository;
        private readonly IMapper _mapper;

        public DeleteElementHandler(IRepository<Element> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ElementResponseDto> Handle(DeleteElementCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null) return null;

            await _repository.DeleteAsync(request.Id);
            return _mapper.Map<ElementResponseDto>(entity);
        }
    }
}
