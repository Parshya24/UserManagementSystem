using Microsoft.AspNetCore.Mvc;
using UserManagementWebApp.ViewModels;
using CommonClassLibrary.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagementWebApp.Services.IServices;

namespace UserManagementWebApp.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("LoginPostAsync")]
        public async Task<IActionResult> LoginPostAsync(LoginViewModel viewModel)
        {
            LoginRequestDto loginRequestDto = new LoginRequestDto
            {
                UserName = viewModel.UserName,
                Password = viewModel.Password
            };
            LoginResponseDto loginResponseDto = await _userManagementService
                                .LoginAsync(loginRequestDto);
            Response.Cookies.Append(
                Constants.XAccessToken,
                loginResponseDto.Token, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict
                });
            return RedirectToAction("Index", "UserProfileManagement");
        }

        public IActionResult SignUp()
        {
            var viewModel = new SignUpViewModel();
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem {Text = SD.RoleAdmin,Value = SD.RoleAdmin},
                new SelectListItem {Text = SD.RoleCustomer,Value = SD.RoleCustomer}
            };
            ViewBag.RoleList = roleList;
            return View("SignUp", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SignUpPost(SignUpViewModel viewModel)
        {
            SignUpRequestDto signUpRequestDto = new SignUpRequestDto
            {
                FirstName = viewModel.FirstName,
                LastName =  viewModel.LastName,
                Email = viewModel.Email,
                Password = viewModel.Password,
                UserName = viewModel.UserName,
                RoleName = viewModel.RoleName


            };
            await _userManagementService.SignUpAsync(signUpRequestDto);

            return RedirectToAction("Index");
        }
    }
}
