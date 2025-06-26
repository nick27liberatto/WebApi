namespace Application.Dto.Request
{
    using Domain.Enums;

    public class ElementRequestDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Text { get; set; }
        public ElementEnum? Status { get; set; }
    }
}
