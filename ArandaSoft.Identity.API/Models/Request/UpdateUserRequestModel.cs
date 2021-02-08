using System;

namespace ArandaSoft.Identity.API.Models.Request
{
    public class UpdateUserRequestModel
    {
        /// <summary>
        /// User external ID. This property is required.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Fullname of the user to be updated.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Physical Addres of the be user to be updated.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Email of the user to be updated
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phonenumber of the user to be updated
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Age of the user to be updated
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// RolId of the user to be updated
        /// </summary>
        public int? RolId { get; set; }
    }
}
