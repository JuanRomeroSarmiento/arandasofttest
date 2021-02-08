namespace ArandaSoft.Identity.Contracts.Dtos
{
    public class LoginRequestDto
    {        
        public string UserName { get; set; }                
        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }        
    }
}
