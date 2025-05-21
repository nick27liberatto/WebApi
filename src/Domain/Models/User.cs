namespace Domain.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; }
        public bool Alive { get; set; }
        public DateTime Birthday { get; set; }
    }
}
