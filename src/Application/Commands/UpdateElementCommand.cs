﻿namespace Application.Commands
{
    using Application.Dto.Response;
    using Domain.Enums;
    using MediatR;

    public class UpdateElementCommand : IRequest<ElementResponseDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Text { get; set; }
        public ElementEnum? Status { get; set; }
    }
}
