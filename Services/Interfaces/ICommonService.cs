using Microsoft.AspNetCore.Mvc;

namespace AutoCareAPI.Services.Interfaces
{
    public interface ICommonService
    {
        Task<dynamic> DynamicNavBar(string userRole);
    }
}
