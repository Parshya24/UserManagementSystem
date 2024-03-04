using CommonClassLibrary.Dto;

namespace UserManagementWebApp.Services.IServices
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
