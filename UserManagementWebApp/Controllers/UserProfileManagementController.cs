using CommonClassLibrary.Dto;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Edit()
        {
            return View();
        }

		public IActionResult Delete()
		{
			return View();
		}

		[HttpPut]
        public async Task<IActionResult> EditUserPut(SignUpViewModel viewModel)
        {
            SignUpRequestDto signUpRequestDto = new SignUpRequestDto
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                Password = viewModel.Password,
                UserName = viewModel.UserName,
                RoleName = viewModel.RoleName


            };
            ///await _userManagementService.SignUpAsync(signUpRequestDto);

            return RedirectToAction("Index");
        }
    }
}
