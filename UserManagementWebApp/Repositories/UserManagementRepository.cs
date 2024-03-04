using Flurl;
using Flurl.Http;
using UserManagementWebApp.Models;
using CommonClassLibrary.Dto;

namespace UserManagementWebApp.Repositories
{
    public class UserManagementRepository : IUserManagementRepository
    {
        public async Task<ResponseDto> SignUpAsync(SignUpRequestDto signUpRequestDto)
        {
            var userSignUp = new UserSignUp
            {
                FirstName = signUpRequestDto.FirstName,
                LastName = signUpRequestDto.LastName,
                Email = signUpRequestDto.Email,
                Password = signUpRequestDto.Password,
                UserName = signUpRequestDto.UserName,
                RoleName = signUpRequestDto.RoleName

            };

            return await SD.AuthAPIBase
                   .AppendPathSegment("/api/auth/SignUp")
                   .PostJsonAsync(userSignUp).ReceiveJson<ResponseDto>();
        }

        public async Task<ResponseDto> AssignRoleAsync(SignUpRequestDto signUpRequestDto)
        {
            var userSignUp = new UserSignUp
            {
                FirstName = signUpRequestDto.FirstName,
                LastName = signUpRequestDto.LastName,
                Email = signUpRequestDto.Email,
                Password = signUpRequestDto.Password,
                UserName = signUpRequestDto.UserName
            };

            return await SD.AuthAPIBase
                   .AppendPathSegment("/api/auth/AssignRole")
                   .PostJsonAsync(userSignUp).ReceiveJson<ResponseDto>();
        }

        public async Task<ResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            var userLogin = new UserLogin
            {
                UserName = loginRequestDto.UserName,
                Password = loginRequestDto.Password
            };

            return await SD.AuthAPIBase
                     .AppendPathSegment("/api/auth/Login")
                     .PostJsonAsync(userLogin).ReceiveJson<ResponseDto>();
        }

        public async Task<ResponseDto> GetUsersAsync()
        {
            return await SD.AuthAPIBase
                     .AppendPathSegment("/api/auth/Users")
                     .GetJsonAsync<ResponseDto>();
        }
    }
}
