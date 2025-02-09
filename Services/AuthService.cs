using AutoCareAPI.Helpers;
using AutoCareAPI.Models.DTOs;
using AutoCareAPI.Repositories.Interfaces;
using AutoCareAPI.Services.Interfaces;

namespace AutoCareAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _userRepo;
        private readonly JwtHelper _jwtHelper;
        public AuthService(IUserRepo userRepo, JwtHelper jwtHelper)
        {
            _userRepo = userRepo;
            _jwtHelper = jwtHelper;
        }

        public async Task<loginResponseModel> userLogin(userLoginModel loginReq)
        {
            try
            {
                var userRes = await _userRepo.authUser(loginReq.userName, loginReq.userPassword);
                if (userRes == null)
                {
                    return null;
                }
                var token = _jwtHelper.GenerateJwtToken(userRes);
                return new loginResponseModel
                {
                    userId = userRes.userId,
                    userName = userRes.userName,
                    userRole= userRes.userRole,
                    token= token
                };
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}
