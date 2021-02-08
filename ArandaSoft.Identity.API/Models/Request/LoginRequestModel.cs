namespace ArandaSoft.Identity.API.Models.Request
{
    public class LoginRequestModel
    {
        /// <summary>
        /// The name of the user. This property is required.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The password of the user. Must be at least 8 characters long. This property is required.
        /// </summary>        
        public string Password { get; set; }
    }
}
