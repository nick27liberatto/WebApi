namespace Application.Commands
{
    using Application.Dto.Response;
    using Domain.Enums;
    using MediatR;

    public class CreateElementCommand : IRequest<ElementResponseDto>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Text { get; set; }
        public ElementEnum? Status { get; set; }
    }
}
