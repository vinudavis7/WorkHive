using BLL;
using BLL.Interface;

using Entities;
using Entities.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkHiveApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {

            var result = await _userService.Register(model);
            return Ok(true );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var result = await _userService.Login(model);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IEnumerable<User> GetAllUsers()
        {
            return _userService.GetUsers();
        }
        [HttpGet("GetDetails/{id}")]
        public User GetUserDetails(string id)
        {
            return _userService.GetUserDetails(id);
        }
 
        [HttpPut("UpdateUser")]
        public bool UpdateUser([FromBody] ProfileViewModel userDetails)
        {
            var result = _userService.UpdateUser(userDetails);
            return result;
        }
        [HttpPut("UpdateProfile")]
        public bool UpdateProfile([FromBody] ProfileViewModel userDetails)
        {
            var result = _userService.UpdateProfile(userDetails);
            return result;
        }



    }
}

