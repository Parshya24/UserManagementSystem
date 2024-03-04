using UserManagementWebApp.Repositories;
using UserManagementWebApp.Services.IServices;
using CommonClassLibrary.Dto;
using Newtonsoft.Json;

namespace UserManagementWebApp.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserManagementRepository _userManagementRepository;

        public UserManagementService(IUserManagementRepository userManagementRepository)
        {
            _userManagementRepository = userManagementRepository;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            LoginResponseDto loginResponseDto = new();

            ResponseDto? response =  await _userManagementRepository.LoginAsync(loginRequestDto);

            if (response != null && response.IsSuccess)
            {
                loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(response.Result));
            }

            return loginResponseDto;
        }

        public async Task SignUpAsync(SignUpRequestDto _signUpRequestDto)
        {
            await _userManagementRepository.SignUpAsync(_signUpRequestDto);
        }

        public async Task AssignRoleAsync(SignUpRequestDto signUpRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
