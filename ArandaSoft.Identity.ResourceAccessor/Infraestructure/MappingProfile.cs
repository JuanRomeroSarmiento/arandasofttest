using ArandaSoft.Identity.Contracts.Dtos;
using ArandaSoft.Identity.Entities;
using AutoMapper;

namespace ArandaSoft.Identity.ResourceAccessor.Infraestructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserInfoDto>()
                .ForMember(dest => dest.Rol, opts => opts.MapFrom(u => u.Rol.Name));
            CreateMap<NewUserDto, User>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(u => u.UserName));
            CreateMap<User, CreatedUserDto>();
            CreateMap<UpdateUserDto, User>()
                .ForMember(uu => uu.Id, opts => opts.MapFrom(u => u.UserId))
                .ForMember(uu => uu.PasswordHash, opts => opts.Ignore())
                .ForMember(uu => uu.Salt, opts => opts.Ignore());
        }
    }
}
