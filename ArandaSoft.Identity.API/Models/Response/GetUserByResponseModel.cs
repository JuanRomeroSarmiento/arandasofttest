using System.Collections.Generic;

namespace ArandaSoft.Identity.API.Models.Response
{
    public class GetUserByResponseModel
    {
        public ICollection<UserInfoResponseModel> Users { get; set; }
    }
}
