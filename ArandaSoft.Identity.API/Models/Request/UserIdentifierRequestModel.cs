using Microsoft.AspNetCore.Mvc;
using System;

namespace ArandaSoft.Identity.API.Models.Request
{
    public class UserIdentifierRequestModel
    {
        /// <summary>
        /// ID of the user to be removed. This property is required.
        /// </summary>
        [FromRoute(Name = "userId")]
        public Guid UserId { get; set; }
    }
}
