using CommonClassLibrary.Dto;

namespace UserManagementWebApp.Repositories
{
    public interface IUserManagementRepository
    {
        Task<ResponseDto> SignUpAsync(SignUpRequestDto signUpRequestDto);

        Task<ResponseDto> LoginAsync(LoginRequestDto loginRequestDto);

        Task<ResponseDto> AssignRoleAsync(SignUpRequestDto signUpRequestDto);

        Task<ResponseDto> GetUsersAsync();

        Task<ResponseDto> GetUserByIdAsync(string userId);

        Task<ResponseDto> EditUserAsync(UserDto user);
    }
}
