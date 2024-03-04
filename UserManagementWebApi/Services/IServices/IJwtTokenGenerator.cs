using UserManagementWebApi.Models;

namespace UserManagementWebApi.Services.IServices
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
