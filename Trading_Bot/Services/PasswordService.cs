namespace AuthenticationService.Services
{
    public class PasswordService : IPaswordService
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if(password == null) throw new ArgumentNullException(nameof(password));
            if(string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException("Value cannot be blank or contain only spaces.", nameof(password));

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if(password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException("Value cannot be blank or contain only spaces.", nameof(password));
            if(storedHash.Length != 64) throw new ArgumentException("Not Verify lenght of the Password-Hash (64 Bytes expect)",nameof(password));
            if (storedSalt.Length != 128) throw new ArgumentException("Not Verify lenght of the Password - Hash(128 Bytes expect)", nameof(password));

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int number = 0; number < computed.Length; number++)
                {
                    if (computed[number] != storedHash[number]) return false;
                }
            }
            return true;
        }
    }
}
