using AutoCareAPI.Models.DTOs;
using AutoCareAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoCareAPI.Controllers
{
    [EnableCors("AllowAny")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonServe;
        public CommonController(ICommonService commonServe)
        {
            _commonServe = commonServe;
        }

        [HttpPost("dynamicNavBar/{user_role}")]
        public async Task<IActionResult> dynamicNavBar([FromRoute] string user_role)
        {
            try
            {
                if (user_role=="")
                {
                    return BadRequest("");
                }
                var navResponse = await _commonServe.DynamicNavBar(user_role);
                if (navResponse == null)
                {
                    return NotFound(null);
                }
                return Ok(navResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
