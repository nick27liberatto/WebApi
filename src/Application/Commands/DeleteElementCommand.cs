namespace Application.Commands
{
    using Application.Dto.Response;
    using MediatR;

    public class DeleteElementCommand : IRequest<ElementResponseDto>
    {
        public int Id { get; set; }
    }
}
