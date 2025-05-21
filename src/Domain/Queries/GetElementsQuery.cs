using Domain.Dto;
using MediatR;

namespace Domain.Queries
{
    public class GetElementsQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
