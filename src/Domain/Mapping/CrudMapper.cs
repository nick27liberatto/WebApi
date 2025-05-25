using AutoMapper;
using Domain.Commands;
using Domain.Dto.Request;
using Domain.Dto.Response;
using Domain.Models;

namespace Domain.Mapping
{
    public class CrudMapper : Profile
    {
        public CrudMapper()
        {
            //Entity to Response
            CreateMap<User, UserResponseDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            
            //Request to Entity
            CreateMap<UserRequestDto, User>();

            //Commands to Entity
            CreateMap<CreateElementCommand, User>();
            CreateMap<UpdateElementCommand, User>();
        }
    }
}
