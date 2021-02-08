using System;

namespace ArandaSoft.Identity.Contracts.Dtos
{
    public class CreatedUserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }        
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? Age { get; set; }
        public int RolId { get; set; }
    }
}
