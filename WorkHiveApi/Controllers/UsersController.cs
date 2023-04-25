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
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;

//Note :User model is derived  from IdentityUser of Identity framework
//so IUserService interface of the framework  is used to handle login,registration and reset password operations
namespace WorkHiveApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;


        public UsersController(ILogger<UsersController> logger, IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _logger = logger;
            _configuration = configuration;
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
        //used  during the registration process
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
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {

            var resteCode = await _userService.forgotPassword(email);
            var webAppBaseURL = _configuration.GetValue<string>("webAppBaseURL");
            var callbackUrl = webAppBaseURL + "/user/resetPassword?email=" + email + "&resetCode=" + resteCode;
            //when user click in the link in the email,they  will be redirected to resetPassword page in MVC application
            string subject = "Reset Password";
            string body = $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>";

            Helper helper = new Helper(_configuration);
            List<string> emailList = new List<string>();
            emailList.Add(email);
            helper.SendEmail(body, subject, emailList);
            return Ok(true);
        }

        [HttpPost("ResetPassowrd")]
        public async Task<IActionResult> ResetPassowrd([FromBody] ResetPasswordRequest password)
        {
            var result = await _userService.ResetPassword(password);
            return Ok(result);
        }
    }
}

