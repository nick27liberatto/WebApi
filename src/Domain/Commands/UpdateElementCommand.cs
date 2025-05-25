using Domain.Dto.Request;
using Domain.Dto.Response;
using Domain.Enums;
using MediatR;

namespace Domain.Commands
{
    public class UpdateElementCommand : IRequest<UserResponseDto>
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
    }
}
