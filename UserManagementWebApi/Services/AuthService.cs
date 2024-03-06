using Microsoft.AspNetCore.Identity;
using UserManagementWebApi.Data;
using CommonClassLibrary.Dto;
using UserManagementWebApi.Models;
using UserManagementWebApi.Services.IServices;

namespace UserManagementWebApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext appDbContext,
                           UserManager<ApplicationUser> userManager,
                           RoleManager<IdentityRole> roleManager,
                           IJwtTokenGenerator jwtTokenGenerator)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
            
        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _appDbContext.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || !isValid)
            {
                return new LoginResponseDto() { Token = "" };  
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            UserDto userDto = new()
            {
                Email = user.Email,
                Id = user.Id,
                Name = $"{user.FirstName} {user.LastName}"
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token
            };

            return loginResponseDto;
        }
        public async Task<string> SignUp(SignUpRequestDto signUpRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = signUpRequestDto.UserName,
                Email = signUpRequestDto.Email,
                NormalizedEmail = signUpRequestDto.Email.ToUpper(),
                FirstName = signUpRequestDto.FirstName,
                LastName = signUpRequestDto.LastName
            };

            try
            {
                var result = await _userManager.CreateAsync(user, signUpRequestDto.Password);
                
                if (result.Succeeded)
                {
                    var userToReturn = _appDbContext.ApplicationUsers.First(u => u.UserName == signUpRequestDto.UserName);

                    UserDto userDto = new()
                    {
                        Email = userToReturn.Email,
                        Id = userToReturn.Id,
                        Name = $"{userToReturn.FirstName} {userToReturn.LastName}"
                    };

                    return "";
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
        public async Task<bool> AssignRole(string userName, string roleName)
        {
            var user = _appDbContext.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());

            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    //create role if it does not exist
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult()   ;
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }
        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = _appDbContext.ApplicationUsers
                          .Select(u => new UserDto
                          {
                              Id = u.Id,
                              Name = $"{u.FirstName} + {u.LastName}",
                              Email = u.Email,
                          })
                          .ToList();
            return users;
        }
    }
}
