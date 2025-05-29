namespace Domain.Queries
{
    using Domain.Dto.Response;
    using MediatR;

    public class GetElementByIdQuery : IRequest<EntityResponseDto>
    {
        public long Id { get; set; }
    }
}
