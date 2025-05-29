using Domain.Enums;

namespace Domain.Dto.Response
{
    public class EntityResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Text { get; set; }
        public string? Status { get; set; }
    }
}
