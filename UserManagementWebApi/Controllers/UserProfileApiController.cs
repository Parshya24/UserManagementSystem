using CommonClassLibrary.Dto;
using Microsoft.AspNetCore.Mvc;
using UserManagementWebApi.Services.IServices;

namespace UserManagementWebApi.Controllers
{
    [Route("api/userprofile")]
    [ApiController]
    public class UserProfileApiController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        protected ResponseDto _response;
        public UserProfileApiController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
            _response = new();
        }

        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser([FromBody] UserDto reqModel)
        {
            var errorMessage = await _userProfileService.EditUser(reqModel);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}
