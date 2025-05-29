using Domain.Enums;

namespace Domain.Dto.Request
{
    public class EntityRequestDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Text { get; set; }
        public EntityEnum? StaticStatus { get; set; }
    }
}
