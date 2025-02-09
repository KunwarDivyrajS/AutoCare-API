using AutoCareAPI.Helpers;
using AutoCareAPI.Models.DTOs;
using AutoCareAPI.Repositories.Interfaces;

namespace AutoCareAPI.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly dbHelper _dbHelper;
        public UserRepo(dbHelper dbHelper) 
        {
            _dbHelper = dbHelper;
        }

        public async Task<loginResponseModel> authUser(string username, string userpassword)
        {
            try
            {
                loginResponseModel userAuth = null;
                var parameters = new Dictionary<string, object>
            {
                { "@userName", username },
                { "@userPassword", userpassword }
            };
                var dataTable = _dbHelper.ExcuteStoredProcedure("sp_AuthenticateUser", parameters);
                if (dataTable.Rows.Count > 0)
                {
                    var result = dataTable.Rows[0];
                    return new loginResponseModel
                    {
                        userId = Convert.ToInt32(result["user_id"]),
                        userName = result["user_name"].ToString(),
                        userRole = result["user_role"].ToString()
                    };
                }
                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
