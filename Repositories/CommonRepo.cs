using AutoCareAPI.Helpers;
using AutoCareAPI.Models.DTOs;
using AutoCareAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoCareAPI.Repositories
{
    public class CommonRepo : ICommonRepo
    {
        private readonly dbHelper _dbHelper;
        public CommonRepo(dbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<dynamic> getDynamicNavBar(string userRole)
        {
            try
            {
               // loginResponseModel userAuth = null;
                var parameters = new Dictionary<string, object>
            {
                { "@user_role", userRole }
            };
                var dataTable = _dbHelper.ExcuteStoredProcedure("sp_getMenuBar", parameters);
                if (dataTable.Rows.Count > 0)
                {
                    var result = dataTable.Rows[0]["MenuJSON"].ToString();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
