namespace Domain.Commands
{
    using Domain.Dto.Response;
    using MediatR;

    public class DeleteElementCommand : IRequest<EntityResponseDto>
    {
        public long Id { get; set; }
    }
}
