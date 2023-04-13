
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

        public async Task<LoginResponse> Login(UserManager<User> context, LoginRequest model)
        {
            try
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
            }

            catch (Exception ex)
            {
                throw ex;
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
                    .Include(user => user.FreelancerReviews)
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
                return dbContext.Profiles.FirstOrDefault();
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
                var obj = dbContext.Users.Where(x => x.Id == user.UserId).FirstOrDefault();
                obj.UserName = user.Name;
                obj.Email = user.Email;
                obj.PhoneNumber = user.Phone;
                obj.Location = user.Location;
                if (!string.IsNullOrEmpty(user.ProfileImage))
                {
                    obj.ProfileImage = user.ProfileImage;

                }

                var profile = dbContext.Profiles.Where(x => x.ProfileId == user.ProfileId).FirstOrDefault();
                profile.Skills = user.Skills;
                profile.Experience = user.Experience;
                profile.Designation = user.Designation;
                profile.Description = user.Description;
                profile.HourlyRate = user.HourlyRate;
                profile.LocationCordinates = user.LocationCordinates;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> CheckIfEmailExists(string email, UserManager<User> userManager)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool UpdateUser(AppDbContext dbContext, ProfileViewModel user)
        {
            try
            {
                var obj = dbContext.Users.Where(x => x.Id == user.UserId).FirstOrDefault();
                obj.UserName = user.Name;
                obj.Email = user.Email;
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
        public void AddReviewToCollection(AppDbContext context, Review review, User user)
        {
            user.FreelancerReviews.Add(review);
        }
        public void AddFreelancerReviewToCollection(AppDbContext context, Review review, User user)
        {
            user.FreelancerReviews.Add(review);
        }
        public void AddClientReviewToCollection(AppDbContext context, Review review, User user)
        {
            user.ClientReviews.Add(review);
        }

    }
}
