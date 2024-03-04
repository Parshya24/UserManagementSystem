using CommonClassLibrary.Dto;
using Microsoft.AspNetCore.Mvc;
using UserManagementWebApp.ViewModels;

namespace UserManagementWebApp.Controllers
{
    public class UserProfileManagementController : Controller
    {
        public IActionResult Index()
        {
            List<UserDto> users = new List<UserDto>();
            return View(users);
        }

        public IActionResult Edit()
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
