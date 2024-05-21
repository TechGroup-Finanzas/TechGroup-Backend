using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TechGroup.API.TechGroup.Users.Request;
using TechGroup.API.TechGroup.Users.Response;
using TechGroup.Domain.TechGroup.Users.Interfaces;
using TechGroup.Infrastructure.TechGroup.Users.Interfaces;
using TechGroup.Infrastructure.TechGroup.Users.Models;

namespace TechGroup.API.TechGroup.Users.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        private readonly IUserInfrastructure _userInfrastructure;

        public UserController(IUserDomain userDomain, IMapper mapper, IUserInfrastructure userInfrastructure)
        {
            _userDomain = userDomain;
            _mapper = mapper;
            _userInfrastructure = userInfrastructure;
        }

        //GET : api/User
        [HttpGet]
        public async Task<List<UserResponse>> GetAllAsync()
        {
            var users = await _userInfrastructure.GetAllAsync();
            var usersResponse = _mapper.Map<List<User>, List<UserResponse>>(users);
            return usersResponse;
        }

        //GET : api/User/5
        [HttpGet("{id}")]
        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var user = await _userInfrastructure.GetByIdAsync(id);
            var userResponse = _mapper.Map<User, UserResponse>(user);
            return userResponse;
        }

        //POST : api/User
        [HttpPost]
        public async Task CreateAsync([FromBody] UserRequest user)
        {
            if (ModelState.IsValid)
            {
                var userToMapped = _mapper.Map<UserRequest, User>(user);
                await _userDomain.SaveAsync(userToMapped);
            }
            else
            {
                StatusCode(400);
            }
        }

        //PUT : api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserRequest user)
        {
            var userToMapped = _mapper.Map<UserRequest, User>(user);
            var userUpdated = await _userDomain.UpdateAsync(id, userToMapped);
            if (userUpdated)
            {
                return Ok();
            }
            return BadRequest();
        }

        //DELETE : api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var userDeleted = await _userDomain.DeleteAsync(id);
            if (userDeleted)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
