using ArandaSoft.Identity.Contracts.Dtos;
using ArandaSoft.Identity.Contracts.Security;
using ArandaSoftware.Identity.Manager.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArandaSoftware.Identity.Manager
{
    public class Manager : IIdentityManager
    {
        private readonly ILocalIdentityService _localIdentityService;
        private readonly IConfiguration _configuration;

        public Manager(
            ILocalIdentityService localIdentityService,
            IConfiguration configuration)
        {
            _localIdentityService = localIdentityService;
            _configuration = configuration;
        }

        public Task<CreatedUserDto> CreateUserAsync(NewUserDto newUserDto)
        {
            Guid newGuid = Guid.NewGuid();
            byte[] salt = Cryptographic.GenerateSalt();
            newUserDto.PasswordHash = Cryptographic.HashPasswordWithSalt(
                Encoding.UTF8.GetBytes(newUserDto.Password), 
                salt);
            newUserDto.Salt = salt;
            return _localIdentityService.CreateUserAsync(newGuid, newUserDto);
        }
        public Task DeledeUserAsync(Guid userId) =>        
            _localIdentityService.DeledeUserAsync(userId);
        public Task<ICollection<UserInfoDto>> GetAllUsersAsync() =>
            _localIdentityService.GetAllUsersAsync();        
        public Task<UserInfoDto> GetUserByUserNameAsync(string name) =>        
            _localIdentityService.GetUserByUserNameAsync(name);
        public Task<ICollection<UserInfoDto>> GetUserByRolAsync(int rolId) =>
            _localIdentityService.GetUserByRolAsync(rolId);
        public async Task<bool> LoginAsync(LoginRequestDto loginRequestDto)
        {
            bool isValid = false;
            UserInfoDto currentUser = await _localIdentityService.GetUserByUserNameAsync(loginRequestDto.UserName);
            byte[] hashedPassword = Cryptographic.HashPasswordWithSalt(
                                                Encoding.UTF8.GetBytes(loginRequestDto.Password),
                                                currentUser.Salt);

            if (hashedPassword.SequenceEqual(currentUser.PasswordHash))
                isValid = true;

            return isValid;
        }            
        public Task UpdateUserInfoAsync(UpdateUserDto updateUserDto) =>
            _localIdentityService.UpdateUserInfoAsync(updateUserDto);
        public async Task<string> GenerateJSONWebToken(string userName)
        {
            UserInfoDto currentUser = 
                await _localIdentityService.GetUserByUserNameAsync(userName);            

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);            

            var claims = GenerateClaims(currentUser);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(5),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private IEnumerable<Claim> GenerateClaims(UserInfoDto user)
        {
            IList<Claim> result = new List<Claim>();
            
            foreach(var permissonDto in user.Permissions)           
                result.Add(new Claim($"{permissonDto.Name}Permission", permissonDto.Name));
            
            return result;
        }
    }
}
