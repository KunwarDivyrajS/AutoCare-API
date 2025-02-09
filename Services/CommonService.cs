using AutoCareAPI.Helpers;
using AutoCareAPI.Models.DTOs;
using AutoCareAPI.Repositories;
using AutoCareAPI.Repositories.Interfaces;
using AutoCareAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoCareAPI.Services
{
    public class CommonService : ICommonService
    {
        private readonly ICommonRepo _commonRepo;
        public CommonService(ICommonRepo commonRepo)
        {
            _commonRepo = commonRepo;
        }

        public async Task<dynamic> DynamicNavBar(string userRole)
        {
            try
            {
                var navRes = await _commonRepo.getDynamicNavBar(userRole);
                if (navRes == null)
                {
                    return null;
                }
                return navRes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
