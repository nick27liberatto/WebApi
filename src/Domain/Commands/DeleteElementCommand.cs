using MediatR;

namespace Domain.Commands
{
    public class DeleteElementCommand : IRequest<long>
    {
        public long Id { get; set; }
    }
}
