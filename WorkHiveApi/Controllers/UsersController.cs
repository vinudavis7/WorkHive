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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            try
            {
                var userList = _userService.GetUsers();
                return Ok(userList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
            }

        }
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {

            var resteCode = await _userService.forgotPassword(email);
            var webAppBaseURL = _configuration.GetValue<string>("webAppBaseURL");
            var callbackUrl = webAppBaseURL+"/user/resetPassword?email=" + email + "&resetCode=" + resteCode;
            string subject = "Reset Password";
            string body = $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>";
            SendEmail(email, subject, body);
            return Ok(true);
        }

        [HttpPost("ResetPassowrd")]
        public async Task<IActionResult> ResetPassowrd([FromBody] ResetPasswordRequest password)
        {
            var result = await _userService.ResetPassword(password);
            return Ok(result);
        }


        public static void SendEmail(string email, string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("notificationsworkhive@gmail.com");
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("notificationsworkhive@gmail.com", "xraypifjhdxqbwvy");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                message.To.Add(new MailAddress(email));
                smtp.Send(message);

            }
            catch (Exception ex)
            {
            }
        }
    }
}

