using Microsoft.AspNetCore.Mvc;

namespace AutoCareAPI.Repositories.Interfaces
{
    public interface ICommonRepo
    {
        Task<dynamic> getDynamicNavBar(string userRole);
    }
}
