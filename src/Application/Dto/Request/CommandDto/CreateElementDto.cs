namespace Application.Dto.Request.CommandDto
{
    using Domain.Enums;

    public class CreateElementDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Text { get; set; }
        public ElementEnum? Status { get; set; }
    }
}
