using System;

namespace ArandaSoft.Identity.Contracts.Dtos
{
    public class NewUserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? Age { get; set; }
        public int RolId { get; set; }
    }
}
