using CommonClassLibrary.Dto;

namespace UserManagementWebApi.Services.IServices
{
    public interface IAuthService
    {
        Task<string> SignUp(SignUpRequestDto signUpRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string userName, string roleName);
        Task<List<UserDto>> GetAllUsers();
    }
}
