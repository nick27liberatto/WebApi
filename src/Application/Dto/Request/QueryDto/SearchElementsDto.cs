namespace Application.Dto.Request.QueryDto
{
    using Domain.Enums;

    public class SearchElementsDto
    {
        public string? Search { get; set; }
        public ElementEnum? Status { get; set; }
    }
}
