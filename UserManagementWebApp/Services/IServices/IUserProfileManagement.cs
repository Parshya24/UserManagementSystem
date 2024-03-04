using CommonClassLibrary.Dto;

namespace UserManagementWebApp.Services.IServices
{
    public interface IUserProfileManagement
    {
        Task EditUserAsync(UserDto userDto);

        Task DeleteUserAsync(UserDto userDto);
    }
}
