using AutoCareAPI.Models.DTOs;
using AutoCareAPI.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AutoCareAPI.Controllers
{
    [EnableCors("AllowAny")]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authServe;
        public AuthController(IAuthService authServe)
        {
            _authServe= authServe;
        }
        [HttpPost("userLogin")]
        public async Task<IActionResult> userLogin([FromBody] userLoginModel loginReq)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var authResponse = await _authServe.userLogin(loginReq);
                if (authResponse == null)
                {
                    return Unauthorized(null);
                }
                return Ok(authResponse);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
