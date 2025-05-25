using AutoMapper;
using Domain.Commands;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Domain.Handlers
{
    public class DeleteElementHandler : IRequestHandler<DeleteElementCommand, long>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public DeleteElementHandler(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<long> Handle(DeleteElementCommand request, CancellationToken cancellationToken)
        {
            return await DeleteElement(request);
        }

        public async Task<long> DeleteElement(DeleteElementCommand request)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new Exception("Element does not exist.");
            }
            await _repository.DeleteAsync(request.Id);
            return _mapper.Map<long>(user);
        }
    }
}
