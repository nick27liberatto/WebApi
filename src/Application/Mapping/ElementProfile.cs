namespace Application.Mapping
{
    using AutoMapper;
    using Dto.Request;
    using Domain.Extensions;
    using Domain.Models;
    using Application.Dto.Response;
    using Application.Commands;
    using Application.Queries;

    public class ElementProfile : Profile
    {
        public ElementProfile()
        {
            //Entity to Response + Get Description from Enumerator
            CreateMap<Element, ElementResponseDto>()
            .ForMember(dest => dest.Status, opt =>
                opt.MapFrom(src => src.StaticStatus.HasValue
                    ? src.StaticStatus.Value.GetDisplayName()
                    : null));

            //Entity to Request
            CreateMap<Element, ElementRequestDto>().ReverseMap();

            //Commands to Entity
            CreateMap<CreateElementCommand, Element>();
            CreateMap<UpdateElementCommand, Element>();
            CreateMap<DeleteElementCommand, Element>();

            //Commands to Dto
            CreateMap<GetElementsRequestDto, GetElementsQuery>();
            CreateMap<CreateElementCommand, ElementResponseDto>();
            CreateMap<UpdateElementCommand, ElementRequestDto>().ReverseMap();
            CreateMap<DeleteElementCommand, ElementRequestDto>();

            //Dto to Commands
            CreateMap<ElementRequestDto, CreateElementCommand>();
        }
    }
}
