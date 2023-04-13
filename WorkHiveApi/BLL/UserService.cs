using BLL.Interface;
using DAL;
using DAL.Repository;
using DAL.Repository.Interface;
using Entities;
using Entities.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BLL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<string> Register(RegisterRequest model)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    User identityUser = new User
                    {
                        UserName = model.Name,
                        Email = model.Email,
                        PhoneNumber = model.Phone,
                        ProfileImage = model.ProfileImage,
                        Location = model.Location
                    };
                    if (model.UserType == "Freelancer")
                    {
                        Profile profile = new Profile
                        {
                            Description = "",
                        };
                        identityUser.Profile = profile;
                    }

                    var result = await _userManager.CreateAsync(identityUser, model.Password);
                    if (result.Succeeded)
                    {
                        var rr = await _userManager.AddToRoleAsync(identityUser, model.UserType);
                        return model.Name;
                    }
                    else
                        return result.ToString();



                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<LoginResponse> Login(LoginRequest model)
        {
            using (_userManager)
            {
                var res = await _userRepository.Login(_userManager, model);
                return res;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    List<User> list = _userRepository.GetUsers(context);
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckIfEmailExists(string email)
        {
            return _userRepository.CheckIfEmailExists(email, _userManager).Result;

        }

        public bool UpdateUser(ProfileViewModel user)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    _userRepository.UpdateUser(context, user);
                    context.SaveChanges();
                }
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateProfile(ProfileViewModel user)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    _userRepository.UpdateProfile(context, user);
                    context.SaveChanges();
                }
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserDetails(string userId)
        {

            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return _userRepository.GetUserDetails(context, userId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User> GetUsersByRole(string role)
        {

            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return _userRepository.GetUsersByRole(context, role);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
