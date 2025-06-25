using Domain.Enums;

namespace Domain.Models
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Text { get; set; }
        public ElementEnum? StaticStatus { get; set; }
    }
}
