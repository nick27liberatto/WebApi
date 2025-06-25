namespace Application.Commands
{
    using Application.Dto.Request;
    using Domain.Enums;
    using MediatR;

    public class UpdateElementCommand : IRequest<ElementRequestDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Text { get; set; }
        public ElementEnum? StaticStatus { get; set; }
    }
}
