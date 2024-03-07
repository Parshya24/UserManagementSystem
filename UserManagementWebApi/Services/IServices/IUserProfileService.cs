using CommonClassLibrary.Dto;

namespace UserManagementWebApi.Services.IServices
{
    public interface IUserProfileService
    {
        Task<string> EditUser(UserDto user);
    }
}
