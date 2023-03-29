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
        
        public bool UpdateUser(ProfileViewModel user);
        public bool UpdateProfile(ProfileViewModel user);

        

    }
}
