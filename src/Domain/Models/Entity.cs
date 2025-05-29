using Domain.Enums;

namespace Domain.Models
{
    public class Entity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Text { get; set; }
        public EntityEnum? StaticStatus { get; set; }
    }
}
