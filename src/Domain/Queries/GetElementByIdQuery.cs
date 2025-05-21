using Domain.Dto;
using MediatR;

namespace Domain.Queries
{
    public class GetElementByIdQuery : IRequest<UserDto>
    {
        public long Id { get; set; }
    }
}
