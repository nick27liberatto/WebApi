namespace Application.Mapping
{
    using AutoMapper;
    using Dto.Request;
    using Domain.Extensions;
    using Domain.Models;
    using Application.Dto.Response;
    using Application.Commands;
    using Application.Queries;
    using Application.Dto.Request.QueryDto;
    using Application.Dto.Request.CommandDto;

    public class ElementProfile : Profile
    {
        public ElementProfile()
        {
            //Entity to Response + Get Description from Enumerator
            CreateMap<Element, ElementResponseDto>()
            .ForMember(dest => dest.Status, opt =>
                opt.MapFrom(src => src.Status.HasValue
                    ? src.Status.Value.GetDisplayName()
                    : null));

            //Entity to Request
            CreateMap<Element, ElementRequestDto>().ReverseMap();

            //Dto to Command/Query
            CreateMap<SearchElementsDto, SearchElementsQuery>();
            CreateMap<CreateElementDto, CreateElementCommand>();
            CreateMap<UpdateElementDto, UpdateElementCommand>();

            //Commands to Entity
            CreateMap<CreateElementCommand, Element>();
            CreateMap<UpdateElementCommand, Element>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


        }
    }
}
