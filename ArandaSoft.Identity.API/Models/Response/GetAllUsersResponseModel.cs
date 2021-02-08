using System.Collections.Generic;

namespace ArandaSoft.Identity.API.Models.Response
{
    public class GetAllUsersResponseModel
    {
        public ICollection<UserInfoResponseModel> Users { get; set; }
    }
}
