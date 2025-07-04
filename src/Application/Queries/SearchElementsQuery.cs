﻿namespace Application.Queries
{
    using Application.Dto.Response;
    using Domain.Enums;
    using MediatR;

    public class SearchElementsQuery : IRequest<IEnumerable<ElementResponseDto>>
    {
        public string? Search { get; set; }
        public ElementEnum? Status { get; set; }
    }
}
