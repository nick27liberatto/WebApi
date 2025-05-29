namespace Domain.Mapping
{
    using AutoMapper;
    using Models;
    using Dto.Response;
    using Dto.Request;
    using Domain.Commands;
    using Domain.Extensions;

    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            //Entity to Response + Get Description from Enumerator
            CreateMap<Entity, EntityResponseDto>()
            .ForMember(dest => dest.Status, opt =>
                opt.MapFrom(src => src.StaticStatus.HasValue
                    ? src.StaticStatus.Value.GetDisplayName()
                    : null));

            //Entity to Request
            CreateMap<Entity, EntityRequestDto>();

            //Request to Entity
            CreateMap<EntityRequestDto, Entity>();

            //Command to Entity
            CreateMap<CreateElementCommand, Entity>();
            CreateMap<UpdateElementCommand, Entity>();
            CreateMap<DeleteElementCommand, Entity>();
        }
    }
}
