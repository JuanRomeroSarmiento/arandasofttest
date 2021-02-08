using Microsoft.AspNetCore.Mvc;

namespace ArandaSoft.Identity.API.Models.Request
{
    public class GetUsersByNameRequestModel
    {
        /// <summary>
        /// Name of the Users to be searched
        /// </summary>
        [FromQuery(Name = "username")]
        public string UserName { get; set; }
    }
}
