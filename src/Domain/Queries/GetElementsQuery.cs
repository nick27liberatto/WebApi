using Domain.Dto.Response;
using MediatR;

namespace Domain.Queries
{
    public class GetElementsQuery : IRequest<IEnumerable<UserResponseDto>>
    {
    }
}
