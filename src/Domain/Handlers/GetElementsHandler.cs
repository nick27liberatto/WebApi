using Domain.Models;
using Domain.Interfaces;
using AutoMapper;
using MediatR;
using Domain.Queries;
using Domain.Dto.Response;

namespace Domain.Handlers
{
    public class GetElementsHandler : IRequestHandler<GetElementsQuery, IEnumerable<UserResponseDto>>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public GetElementsHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponseDto>> Handle(GetElementsQuery request, CancellationToken cancellationToken)
        {
            return await GetElements(request);
        }

        public async Task<IEnumerable<UserResponseDto>> GetElements(GetElementsQuery request)
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }
    }
}
