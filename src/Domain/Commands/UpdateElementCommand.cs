using Domain.Dto;
using MediatR;

namespace Domain.Commands
{
    public class UpdateElementCommand : IRequest<UserDto>
    {
        public long Id { get; set; }
    }
}
