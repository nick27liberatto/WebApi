using AutoMapper;
using Domain.Commands;
using Domain.Dto.Request;
using Domain.Dto.Response;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Domain.Handlers
{
    public class UpdateElementHandler : IRequestHandler<UpdateElementCommand, UserResponseDto>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UpdateElementHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserResponseDto> Handle(UpdateElementCommand request, CancellationToken cancellationToken)
        {
            return await UpdateElement(request);
        }

        public async Task<UserResponseDto> UpdateElement(UpdateElementCommand request)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new Exception("Element does not exist.");
            }
            _mapper.Map(request, user);
            await _repository.UpdateAsync(user);
            return _mapper.Map<UserResponseDto>(user);
        }
    }
}
