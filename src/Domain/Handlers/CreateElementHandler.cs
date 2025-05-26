using AutoMapper;
using Domain.Commands;
using Domain.Dto.Response;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Domain.Handlers
{
    public class CreateElementHandler : IRequestHandler<CreateElementCommand, UserResponseDto>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        public CreateElementHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserResponseDto> Handle(CreateElementCommand request, CancellationToken cancellationToken)
        {
            return await CreateElement(request);
        }
        public async Task<UserResponseDto> CreateElement(CreateElementCommand request)
        {
            var exists = _repository.GetByIdAsync(request.Id);
            if (exists != null)
            {
                throw new Exception("Element already exists.");
            }
            var user = _mapper.Map<User>(request);
            await _repository.AddAsync(user);
            return _mapper.Map<UserResponseDto>(user);
        }
    }
}
