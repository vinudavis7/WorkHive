
using DAL.Repository.Interface;
using Entities;
using Entities.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    [Authorize]

    public class UserRepository : IUserRepository
    {

        public async Task<IdentityUser> RegisterIdentityUser(UserManager<User> context, RegisterRequest model, IdentityUser user)
        {
            try
            {
                //var identityUser = new IdentityUser { UserName = model.Name, Email = model.Email, PhoneNumber = model.Phone };
                //var passwordHash = new PasswordHasher<IdentityUser>().HashPassword(identityUser, model.Password);
                //user.PasswordHash = passwordHash;


                // r =await context.CreateAsync(user, model.Password);
                // var rr=    await context.AddToRoleAsync(user, model.UserType);

                return user;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> RegisterApplicationUser(AppDbContext dbContext, User user)
        {
            try
            {
                dbContext.Users.Add(user);
                return user.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> CreateProfile(AppDbContext dbContext, Profile profile)
        {
            try
            {
                dbContext.Profiles.Add(profile);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<LoginResponse> Login(UserManager<User> context, LoginRequest model)
        {
            var user = await context.FindByEmailAsync(model.Username);

            if (user != null && await context.CheckPasswordAsync(user, model.Password))
            {
                var roles = await context.GetRolesAsync(user);

                // Create a new JWT token with the user's roles as claims
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, string.Join(",", roles))
                    }),
                    Audience = "https://localhost:7223/",// Add audience claim ,
                    Issuer = "https://localhost:7223/",
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

                return new LoginResponse
                {
                    UserId = user.Id,
                    Name = user.UserName,
                    Role = string.Join(",", roles),
                    Token = handler.WriteToken(token)
                };

            }
            return null;
        }

        public List<User> GetUsers(AppDbContext dbContext)
        {
            try
            {
                List<User> userList = dbContext.Users
                .Include(user => user.Profile)
                .ToList();



                return userList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<User> GetUsersByRole(AppDbContext dbContext, string role)
        {
            try
            {
                var list = dbContext.Users
      .Where(user => user.Profile != null)
 .Include(user => user.Profile)
 .ToList();
                // res= await _userManager.GetUsersInRoleAsync(role);
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<Profile> GetUserProfiles(AppDbContext dbContext)
        {
            try
            {
                List<Profile> profileList = dbContext.Profiles
                // .Include(user => user.User)
                //.ThenInclude(u => u.IdentityUser)
                .ToList();
                return profileList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserDetails(AppDbContext dbContext, string userId)
        {
            try
            {
                return dbContext.Users.
                    Include(user => user.Profile)
                    .Include(user => user.Bids)
                    .Include(user => user.Jobs).ThenInclude(user => user.Bids)
                    .Where(x => x.Id == userId)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Profile GetProfileDetails(AppDbContext dbContext, string userId)
        {
            try
            {
                return dbContext.Profiles
                    //Include(user => user.IdentityUser)
                    //.Where(x => x.User.Id == userId)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task<int> GetUserCount(UserManager<User> userManager, string userType)
        {
            try
            {
                var users = await userManager.GetUsersInRoleAsync(userType);
                var userCount = users.Count;
                return userCount;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateProfile(AppDbContext dbContext, ProfileViewModel user)
        {
            try
            {
                var obj = dbContext.Users
                    //.Include(user => user.IdentityUser)
                    .Where(x => x.Id == user.UserId).FirstOrDefault();
                obj.UserName = user.Name;
                obj.Email = user.Email;
                // obj.IdentityUser.Password = user.Password;
                obj.PhoneNumber = user.Phone;
                obj.Location = user.Location;
                obj.ProfileImage = user.ProfileImage;

                var profile = dbContext.Profiles
                    //.Include(user => user.IdentityUser)
                    .Where(x => x.ProfileId == user.ProfileId).FirstOrDefault();
                profile.Skills = user.Skills;
                profile.Experience = user.Experience;
                profile.Designation = user.Designation;
                profile.Description = user.Description;
                profile.HourlyRate = user.HourlyRate;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateUser(AppDbContext dbContext, ProfileViewModel user)
        {
            try
            {
                var obj = dbContext.Users
                   //.Include(user => user.IdentityUser)
                   .Where(x => x.Id == user.UserId).FirstOrDefault();
                obj.UserName = user.Name;
                obj.Email = user.Email;
                // obj.IdentityUser.Password = user.Password;
                obj.PhoneNumber = user.Phone;
                obj.Location = user.Location;
                obj.ProfileImage = user.ProfileImage;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddJobToCollection(AppDbContext context, Job job, User user)
        {
            user.Jobs.Add(job);
        }
        public void AddBidToCollection(AppDbContext context, Bid bid, User user)
        {
            user.Bids.Add(bid);
        }

    }
}
