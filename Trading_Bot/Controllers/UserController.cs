using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Models;
using AuthenticationService.Services;
using DataBase.Helper;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserController (IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsersModel.RegisterDo registerDo)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                await _authService.RegisterAsync(registerDo.Username, registerDo.Password);
                return Ok(ResponseHandler.GetApiResponse(type, "Registry was success"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsersModel.LoginDto loginDto)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                var user = await _authService.Login(loginDto.Username, loginDto.Password);
                if(user == null) 
                {
                    return Unauthorized();
                }

                return Ok(ResponseHandler.GetApiResponse(type, "Login was success"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete("deleteuser/{id}")]
        public IActionResult Deleteuser(int id)
        {
            try
            {
                ResponseType response = ResponseType.Success;
                _authService.DeleteUser(id);
                return Ok(ResponseHandler.GetApiResponse(response, "Delete successfully"));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
