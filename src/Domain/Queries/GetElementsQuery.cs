namespace Domain.Queries
{
    using Domain.Enums;
    using Dto.Response;
    using MediatR;

    public class GetElementsQuery : IRequest<IEnumerable<EntityResponseDto>>
    {
        public string? Search { get; set; }
        public EntityEnum? Status { get; set; }
    }
}
