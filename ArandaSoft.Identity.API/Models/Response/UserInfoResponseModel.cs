using System;

namespace ArandaSoft.Identity.API.Models.Response
{
    public class UserInfoResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? Age { get; set; }
        public string Rol { get; set; }
    }
}
