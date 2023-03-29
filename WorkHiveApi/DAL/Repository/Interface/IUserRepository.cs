
using Entities;
using Entities.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public  interface IUserRepository
    {

        public Task<IdentityUser> RegisterIdentityUser(UserManager<User> userManager, RegisterRequest model,IdentityUser user);
        public Task<string> RegisterApplicationUser(AppDbContext dbContext,User user);
        public  Task<bool> CreateProfile(AppDbContext dbContext, Profile profile);


        public Task<LoginResponse> Login(UserManager<User> userManager,LoginRequest model);
        public List<User> GetUsers(AppDbContext dbContext);
        public List<Profile> GetUserProfiles(AppDbContext dbContext);

        public User GetUserDetails(AppDbContext dbContext,string userId);
        public Profile GetProfileDetails(AppDbContext dbContext, string userId);
        public List<User> GetUsersByRole(AppDbContext dbContext, string role);

        //public User GetUserDetails(string username, string password);
        //public User CreateUser(User user);
        public Task<int> GetUserCount(UserManager<User> userManager, string userType);

        public bool UpdateUser(AppDbContext dbContext, ProfileViewModel user);
        public bool UpdateProfile(AppDbContext dbContext, ProfileViewModel profile);
        
        public void AddJobToCollection(AppDbContext context,Job job,User user);
        public void AddBidToCollection(AppDbContext context, Bid bid, User user);


    }
}
