using CommonClassLibrary.Dto;
using Microsoft.AspNetCore.Identity;
using UserManagementWebApi.Models;
using UserManagementWebApi.Services.IServices;

namespace UserManagementWebApi.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> EditUser(UserDto userDto)
        {
            ApplicationUser user = new()
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                NormalizedEmail = userDto.Email.ToUpper(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Id = userDto.Id
            };

            try
            {
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return "The user updated successfully.";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
