using Microsoft.AspNetCore.Mvc;

namespace ArandaSoft.Identity.API.Models.Request
{
    public class GetUsersByRolIdRequestModel
    {
        /// <summary>
        /// ID number of the rol to be searched
        /// </summary>
        /// 
        [FromQuery(Name = "rolId")]
        public int RolId { get; set; }
    }
}
