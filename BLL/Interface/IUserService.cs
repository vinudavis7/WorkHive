using DAL;

using Entities;
using Entities.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public  interface IUserService
    {
        public Task<string> Register(RegisterRequest user);
        public Task<LoginResponse> Login(LoginRequest mode);
        public List<User> GetUsers();
        public User GetUserDetails(string userId);
        public bool CheckIfEmailExists(string email);
        public bool UpdateUser(ProfileViewModel user);
        public bool UpdateProfile(ProfileViewModel user);
        public List<User> GetUsersByRole(string role);
        public Task<string> forgotPassword(string email);
        public Task<bool> ResetPassword(ResetPasswordRequest passwordRequest);


    }
}
