using ArandaSoft.Identity.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArandaSoftware.Identity.Manager.Interfaces
{
    public interface ILocalIdentityService
    {        
        Task<ICollection<UserInfoDto>> GetAllUsersAsync();
        Task<UserInfoDto> GetUserByUserNameAsync(string name);
        Task<ICollection<UserInfoDto>> GetUserByRolAsync(int rolId);
        Task UpdateUserInfoAsync(UpdateUserDto updateUserDto);
        Task<CreatedUserDto> CreateUserAsync(Guid newId, NewUserDto newUserDto);
        Task DeledeUserAsync(Guid userId);
    }
}
