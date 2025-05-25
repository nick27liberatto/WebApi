using Domain.Dto.Response;
using MediatR;

namespace Domain.Queries
{
    public class GetElementByIdQuery : IRequest<UserResponseDto>
    {
        public long Id { get; set; }
    }
}
