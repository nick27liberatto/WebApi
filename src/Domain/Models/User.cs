using Domain.Enums;

namespace Domain.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public StatusUserEnum Status { get; set; }
    }
}
