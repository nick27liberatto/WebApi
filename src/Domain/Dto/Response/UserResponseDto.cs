using Domain.Enums;

namespace Domain.Dto.Response
{
    public class UserResponseDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}
