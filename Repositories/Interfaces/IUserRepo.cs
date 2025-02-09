using AutoCareAPI.Models.DTOs;

namespace AutoCareAPI.Repositories.Interfaces
{
    public interface IUserRepo
    {
        Task<loginResponseModel> authUser(string username, string userpassword);
    }
}
