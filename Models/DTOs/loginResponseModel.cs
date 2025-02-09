namespace AutoCareAPI.Models.DTOs
{
    public class loginResponseModel
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userRole { get; set; }
        public string token { get; set; }
        //public DateTime? TokenExpiry { get; set; }
    }
}
