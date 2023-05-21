using AuthenticationService.Modells;
using DataBase.DataContext;

namespace AuthenticationService.Services
{
    public interface IUserRepository
    {
        Task<Users> GetUSerByUsername(string username);

        Task CreateUser(Users user);
    }
}
