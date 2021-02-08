using ArandaSoft.Identity.Contracts.Dtos;
using ArandaSoft.Identity.ResourceAccessor.Interfaces;
using ArandaSoftware.Identity.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArandaSoftware.Identity.Manager.Services
{
    public class LocalIdentityService : ILocalIdentityService
    {
        private readonly IUserRepository _userRepository;

        public LocalIdentityService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public Task<CreatedUserDto> CreateUserAsync(Guid newId, NewUserDto newUserDto) =>
            _userRepository.CreateUserAsync(newId, newUserDto);
        public Task DeledeUserAsync(Guid userId) =>
            _userRepository.DeledeUserAsync(userId);
        public Task<ICollection<UserInfoDto>> GetAllUsersAsync() =>
            _userRepository.GetAllUsersAsync();        
        public Task<UserInfoDto> GetUserByUserNameAsync(string name) =>
            _userRepository.GetUserByUserNameAsync(name);
        public Task<ICollection<UserInfoDto>> GetUserByRolAsync(int rolId) =>
            _userRepository.GetUserByRolAsync(rolId);        
        public Task UpdateUserInfoAsync(UpdateUserDto updateUserDto) =>
            _userRepository.UpdateUserInfoAsync(updateUserDto);
    }
}
