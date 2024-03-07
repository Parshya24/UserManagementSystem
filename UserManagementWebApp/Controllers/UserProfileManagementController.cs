using CommonClassLibrary.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserManagementWebApp.Services.IServices;
using UserManagementWebApp.ViewModels;

namespace UserManagementWebApp.Controllers
{
    public class UserProfileManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;
        
        public UserProfileManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public IActionResult Index()
        {
            var users = _userManagementService.GetAllUsersAsync().Result;
            return View(users);
        }

        public IActionResult Edit(string id)
        {
            var user =  _userManagementService.GetUserByIdAsync(id).Result;
            return View("EditUser", user);
        }

		[HttpPut]
        public async Task<IActionResult> EditUserPut(UserDto viewModel)
        {
            await _userManagementService.EditUserAsync(viewModel);

            return RedirectToAction("Index");
        }
    }
}
