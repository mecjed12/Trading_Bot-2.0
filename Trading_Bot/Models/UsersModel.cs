namespace AuthenticationService.Models
{
    public class UsersModel
    {
        public class RegisterDo
        {
            public string? Username { get; set; }
            
            public string? Password { get; set; }
        }

        public class LoginDto
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

    }
}


