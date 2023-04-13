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
using System.Net.Http;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkHiveApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;


        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            try
            {
                var result = await _userService.Register(model);
                if (result.Contains("Failed"))
                    return Ok(false);
                else
                    return Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            try
            {
                var result = await _userService.Login(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var userList = _userService.GetUsers();
                return Ok(userList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }
        [HttpGet("GetDetails/{id}")]
        public IActionResult GetUserDetails(string id)
        {
            try
            {
                var userDetails = _userService.GetUserDetails(id);
                return Ok(userDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }
        [HttpGet("GetUsersByRole/{role}")]
        public IActionResult GetUsersByRole(string role)
        {
            try
            {
                var result = _userService.GetUsersByRole(role);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }
        [HttpGet("CheckIfEmailExists/{email}")]
        public IActionResult CheckIfEmailExists(string email)
        {
            try
            {
                var result = _userService.CheckIfEmailExists(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }


        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] ProfileViewModel userDetails)
        {
            try
            {
                var result = _userService.UpdateUser(userDetails);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }
        [HttpPut("UpdateProfile")]
        public IActionResult UpdateProfile([FromBody] ProfileViewModel userDetails)
        {
            try
            {
                var result = _userService.UpdateProfile(userDetails);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }
        [HttpGet("health")]
        public async Task<IActionResult> CheckHealthAsync()
        {
            var userList = _userService.GetUsers();
            return Ok(userList);
        }
    }
}

