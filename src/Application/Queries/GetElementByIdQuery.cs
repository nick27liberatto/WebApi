namespace Application.Queries
{
    using Application.Dto.Response;
    using MediatR;

    public class GetElementByIdQuery : IRequest<ElementResponseDto>
    {
        public int Id { get; set; }
    }
}
