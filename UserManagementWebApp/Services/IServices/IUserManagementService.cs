using CommonClassLibrary.Dto;

namespace UserManagementWebApp.Services.IServices
{
    public interface IUserManagementService
    {
        Task SignUpAsync(SignUpRequestDto signUpRequestDto);

        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto);

        Task<List<UserDto>> GetAllUsersAsync();

        Task EditUserAsync(UserDto userDto);

        Task<UserDto> GetUserByIdAsync(string userId);
    }
}
