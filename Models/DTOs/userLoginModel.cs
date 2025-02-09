using System.ComponentModel.DataAnnotations;

namespace AutoCareAPI.Models.DTOs
{
    public class userLoginModel
    {
        [Required]
        [MaxLength(50)]
        public string userName { get; set; }

        [Required]
        [MaxLength(50)]
        public string userPassword { get; set; }
    }
}
