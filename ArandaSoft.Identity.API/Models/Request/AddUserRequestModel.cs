namespace ArandaSoft.Identity.API.Models.Request
{
    public class AddUserRequestModel
    {
        /// <summary>
        /// The UserName of the new User. This property is required.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///  Must be at least 8 characters long. This property is required. 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Full name of the new User. This property is required.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Physical Address of the new User. 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Email of the new User. This property is required.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// PhoneNumber of the new User.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Age of the new User. 
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Rol Id of the new User. This property is required.
        /// </summary>
        public int RolId { get; set; }
    }
}
