using Domain.Dto.Response;
using MediatR;

namespace Domain.Commands
{
    public class CreateElementCommand : IRequest<UserResponseDto>
    {
        public long Id { get; set; }
    }
}
