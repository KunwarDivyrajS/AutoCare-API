using AutoCareAPI.Models.DTOs;

namespace AutoCareAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<loginResponseModel> userLogin(userLoginModel loginReq);
    }
}
