using CommonClassLibrary.Dto;

namespace UserManagementWebApp.Services.IServices
{
    public interface IUserManagementService
    {
        Task SignUpAsync(SignUpRequestDto signUpRequestDto);

        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto);

        Task AssignRoleAsync(SignUpRequestDto signUpRequestDto);
    }
}
