using AuthenticationService.Modells;

using DataBase.DataContext;
using DataBase.DataContext.Tables;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataBaseContext _context;

        public UserRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task CreateUser(Users user)
        {
            var dbUser = new DBUser
            {
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
            };

            _context.Users.Add(dbUser);
            await _context.SaveChangesAsync();
        }

        public async Task<Users> GetUSerByUsername(string username)
        {
            var dbUser = await _context.Users.SingleOrDefaultAsync(o => o.UserName == username);
            if(dbUser == null)
            {
                return null;
            }
            return new Users
            {
                Id = dbUser.Id,
                UserName = dbUser.UserName,
                PasswordHash = dbUser.PasswordHash,
                PasswordSalt = dbUser.PasswordSalt,
            };
        }

       
        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int number = 0; number < computed.Length; number++)
                {
                    if (computed[number] != storedHash[number]) return false;
                }
            }
            return true;
        }
    }
}
