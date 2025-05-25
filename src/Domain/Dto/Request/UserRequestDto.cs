using Domain.Enums;

namespace Domain.Dto.Request
{
    public class UserRequestDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public StatusUserEnum Status { get; set; }
    }
}
