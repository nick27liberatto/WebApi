namespace Application.Dto.Request
{
    using Domain.Enums;

    public class GetElementsRequestDto
    {
        public string? Search { get; set; }
        public ElementEnum? Status { get; set; }
    }
}
