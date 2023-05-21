namespace AuthenticationService.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(string usernmae, string password);
        Task<string> Login(string username, string password);

    }
}
