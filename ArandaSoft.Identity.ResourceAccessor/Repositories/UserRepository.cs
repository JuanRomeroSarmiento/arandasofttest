using ArandaSoft.Identity.Contracts.Dtos;
using ArandaSoft.Identity.Entities;
using ArandaSoft.Identity.ResourceAccessor.Interfaces;
using ArandSoft.Identity.DataBase;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArandaSoft.Identity.ResourceAccessor.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityDBContext _context;
        private readonly IMapper _mapper;

        public UserRepository(IdentityDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserInfoDto> GetUserByUserNameAsync(string name)
        {
            User user = await _context.User
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.Name == name);

            if (user == null)
                throw new KeyNotFoundException($"User {name} not found.");

            var permissionsUser = await _context.RolPermission
                .Include(rp => rp.Rol)
                .Include(rp => rp.Permission)
                .Where(rp => rp.RolId == user.RolId)
                .Select(p => new PermissionDto {  Name = p.Permission.Name } )
                .ToListAsync();

            var userDto = _mapper.Map<User, UserInfoDto>(user);
            userDto.Permissions = permissionsUser;
            return userDto;
        }
        public async Task<ICollection<UserInfoDto>> GetUserByRolAsync(int rolId)
        {
            ICollection<User> users = await _context.User
                .Include(u => u.Rol)
                .Where(u => u.RolId == rolId)
                .ToListAsync();

            if (users == null)
                throw new KeyNotFoundException($"Rol {rolId} not found.");

            return _mapper.Map<ICollection<User>, ICollection<UserInfoDto>>(users);
        }
        public async Task<CreatedUserDto> CreateUserAsync(Guid newId, NewUserDto newUserDto)
        {
            //TODO: Validate the existance of the password
            User newUser = _mapper.Map<NewUserDto, User>(newUserDto);
            newUser.Id = newId;
            _context.User.Add(newUser);
            await _context.SaveChangesAsync();

            return await _context.User
                .ProjectTo<CreatedUserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(u => u.Id == newId);
        }
        public async Task UpdateUserInfoAsync(UpdateUserDto updateUserDto)
        {
            User databaseUser = await _context.User
                .FirstOrDefaultAsync(u => u.Id == updateUserDto.UserId);

            if (databaseUser == null)            
                throw new KeyNotFoundException($"User {updateUserDto.UserId} not found.");
            

            if (updateUserDto.Name != null)
                databaseUser.Name = updateUserDto.Name;
            if (updateUserDto.FullName != null)
                databaseUser.FullName = updateUserDto.FullName;
            if (updateUserDto.Address != null)
                databaseUser.Address = updateUserDto.Address;
            if (updateUserDto.Email != null)
                databaseUser.Email = updateUserDto.Email;
            if (updateUserDto.PhoneNumber != null)
                databaseUser.PhoneNumber = updateUserDto.PhoneNumber;
            if (updateUserDto.Age != null)
                databaseUser.Age = updateUserDto.Age;
            if (updateUserDto.RolId >= 1 && updateUserDto.RolId <= 4)
                databaseUser.RolId = updateUserDto.RolId;

            _context.Entry(databaseUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeledeUserAsync(Guid userId)
        {
            User dataBaseUser = await _context.User
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (dataBaseUser == null)            
                throw new KeyNotFoundException($"User {userId} not found.");
            

            _context.User.Remove(dataBaseUser);
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<UserInfoDto>> GetAllUsersAsync()
        {
            ICollection<User> allUsers = await _context.User
                    .Include(u => u.Rol)
                    .ToListAsync();
            return _mapper.Map<ICollection<User>, ICollection<UserInfoDto>>(allUsers);
        }
    }
}
