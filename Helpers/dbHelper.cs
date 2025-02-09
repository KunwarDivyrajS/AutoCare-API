using System.Data;
using System.Data.SqlClient;

namespace AutoCareAPI.Helpers
{
    public class dbHelper
    {
        private readonly string _connectionString;
        public dbHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("dbConn");
        }
        public DataTable ExcuteStoredProcedure(string storedProc, Dictionary<string,object>Params)
        {
             using (var conn = new SqlConnection(_connectionString))
             using (var command = new SqlCommand(storedProc, conn))
             {
                 command.CommandType = CommandType.StoredProcedure;
                 if (Params != null)
                 {
                     foreach (var param in Params)
                     {
                         command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                     }
                 }
             
                 conn.Open();
                 using (var adapter = new SqlDataAdapter(command))
                 {
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                 }
             }
            


        }
    }
}
