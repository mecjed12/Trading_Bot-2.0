using AuthenticationService.Helper;
using AuthenticationService.Modells;
using DataBase.DataContext;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationService.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPaswordService _paswordService;
        private readonly AppSettings _config;
        private readonly IDataBaseContext _dataBaseContext;

        public AuthService(IUserRepository userRepository, IPaswordService paswordService,IOptions<AppSettings> appSettings,IDataBaseContext dataBaseContext)
        {
            _userRepository = userRepository;
            _paswordService = paswordService;
            _config = appSettings.Value;
            _dataBaseContext = dataBaseContext;
        }

        public async Task RegisterAsync(string usernmae, string password)
        {
            if(string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Passwrod is necessary");


            if (await _userRepository.GetUSerByUsername(usernmae) != null)
                throw new ApplicationException($"The Username {usernmae} is already occupied");

            byte[] passwordHash, passwordSalt;
            _paswordService.CreatePasswordHash(password,out passwordHash, out passwordSalt);

            var user = new Users
            {
                UserName = usernmae,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _userRepository.CreateUser(user);
        }

        public async Task<string> Login (string username, string password)
        {
            var user = await _userRepository.GetUSerByUsername(username);

            if (user == null)
                throw new ApplicationException("Username or Password is wrong");

            if (!_paswordService.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new ApplicationException("Username or password is wrong");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.Secret);
            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDecriptor);
            return tokenHandler.WriteToken(token);
        }

        public void DeleteUser(int id)
        {
            var user = _dataBaseContext.users.Where(o => o.Id.Equals(id)).FirstOrDefault();
            if(user != null)
            {
                _dataBaseContext.users.Remove(user);
                _dataBaseContext.SaveChanges();
            }
        }
    }
}
