using ArandaSoft.Identity.API.Models.Request;
using ArandaSoft.Identity.API.Models.Response;
using ArandaSoft.Identity.Contracts.Dtos;
using AutoMapper;

namespace ArandaSoft.Identity.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginRequestModel, LoginRequestDto>();
            CreateMap<UserInfoDto, UserInfoResponseModel>();                
            CreateMap<AddUserRequestModel, NewUserDto>();
            CreateMap<UpdateUserRequestModel, UpdateUserDto>();
        }
    }
}
