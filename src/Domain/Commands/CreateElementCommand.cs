using MediatR;

namespace Domain.Commands
{
    public class CreateElementCommand : IRequest<long>
    {
        public long Id { get; set; }
    }
}
