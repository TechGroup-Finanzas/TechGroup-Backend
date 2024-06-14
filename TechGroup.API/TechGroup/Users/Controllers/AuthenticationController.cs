using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TechGroup.API.TechGroup.Users.Request;
using TechGroup.Infrastructure.TechGroup.Users.Interfaces;
using TechGroup.Infrastructure.TechGroup.Users.Models;


namespace TechGroup.API.TechGroup.Users.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserInfrastructure _userInfrastructure;

        public AuthenticationController(IUserInfrastructure userInfrastructure)
        {
            _userInfrastructure = userInfrastructure;
        }

        // POST: api/Authentication
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                var response = await _userInfrastructure.LoginAsync(loginRequest.Email, loginRequest.Password);
                if(response.Success)
                {
                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(400, response);
                }
            }
            else
            {
                return StatusCode(400, "Invalid request");
            }
        }
    }
}
