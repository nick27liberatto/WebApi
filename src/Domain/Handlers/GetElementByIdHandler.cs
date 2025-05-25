using AutoMapper;
using Domain.Dto.Response;
using Domain.Interfaces;
using Domain.Models;
using Domain.Queries;
using MediatR;

namespace Domain.Handlers
{
    public class GetElementByIdHandler : IRequestHandler<GetElementByIdQuery, UserResponseDto>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public GetElementByIdHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserResponseDto> Handle(GetElementByIdQuery request, CancellationToken cancellationToken)
        {
            return await GetById(request);
        }
        public async Task<UserResponseDto> GetById(GetElementByIdQuery request)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<UserResponseDto>(user);
        }
    }
}
