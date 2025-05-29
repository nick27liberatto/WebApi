namespace Domain.Commands
{
    using Domain.Dto.Request;
    using Domain.Enums;
    using MediatR;
    using System.Text.Json.Serialization;

    public class UpdateElementCommand : IRequest<EntityRequestDto>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Text { get; set; }
        public EntityEnum? StaticStatus { get; set; }

        [JsonIgnore]
        public long Id { get; set; }
    }
}
