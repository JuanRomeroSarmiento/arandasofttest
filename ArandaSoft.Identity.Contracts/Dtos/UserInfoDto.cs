using System;
using System.Collections.Generic;

namespace ArandaSoft.Identity.Contracts.Dtos
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? Age { get; set; }
        public string Rol { get; set; }  
        public ICollection<PermissionDto> Permissions { get; set; }
    }
}
