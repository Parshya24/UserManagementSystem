using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CommonClassLibrary.Dto;
using UserManagementWebApi.Services.IServices;

namespace UserManagementWebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;
        public AuthApiController(IAuthService authService)
        {
            _authService = authService;
            _response = new();
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto reqModel)
        {
            var errorMessage = await _authService.SignUp(reqModel);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto reqModel)
        {
            var loginResponse = await _authService.Login(reqModel);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = $"Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole ([FromBody] SignUpRequestDto reqModel)
        {
            var assignRoleSuccessful = await _authService.AssignRole(reqModel.UserName, reqModel.RoleName.ToUpper());
            if (assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = $"Error encountered";
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpGet("Users")]
        public async Task<IActionResult> Users()
        {
            var users = await _authService.GetAllUsers();
            if (!users.Any())
            {
                _response.IsSuccess = false;
                _response.Message = $"No Data found";
                return BadRequest(_response);
            }
            _response.Result = users;
            return Ok(_response);
        }
    }
}
