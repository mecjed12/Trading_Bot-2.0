namespace AuthenticationService.Services
{
    public interface IPaswordService
    {
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}
