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

namespace BLL
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository userRepository,UserManager<User> userManager)
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
                    // Create a new instance of the IdentityUser class
                    User identityUser = new User
                    {
                        UserName = model.Name,
                        Email = model.Email,
                        PhoneNumber = model.Phone,
                        // NormalizedEmail = model.Email,
                        ProfileImage = model.ProfileImage,
                        Location = model.Location

                    };
                    if (model.UserType == "Freelancer")
                    {
                        Profile profile = new Profile
                        {
                            Description = "asd",
                        };
                        identityUser.Profile = profile;
                       // _userRepository.CreateProfile(context, profile);
                       // context.SaveChanges();
                    }
                   // else
                        //{
                        var result = await _userManager.CreateAsync(identityUser, model.Password);

                        if (result.Succeeded)
                        {
                            var rr = await _userManager.AddToRoleAsync(identityUser, model.UserType);
                        }
                   // }
                    
                    
                    //using (AppDbContext context = new AppDbContext())
                    //    {
                    //        using ( _userManager )
                    //        {
                    //            var identityUser = new IdentityUser { UserName = model.Name, Email = model.Email, PhoneNumber = model.Phone,
                    //            NormalizedEmail=model.Email};


                    //            User user = new User
                    //            {
                    //                Id = Guid.NewGuid().ToString(), // generate a new unique Id
                    //                Location = model.Location,
                    //                ProfileImage = model.ProfileImage,
                    //                IdentityUser = identityUser // use the newly created IdentityUser object
                    //            };

                    //            //IdentityResult r = await _userManager.CreateAsync(identityUser, model.Password);
                    //            await _userManager.AddToRoleAsync(identityUser, model.UserType);

                    //            context.Users.Add(user);
                    //            context.SaveChanges();
                    //            if (model.UserType == "Freelancer")
                    //            {
                    //                Profile profile = new Profile
                    //                {
                    //                    Description = "asd",
                    //                    User = user
                    //                };
                    //                _userRepository.CreateProfile(context, profile);
                    //                context.SaveChanges();
                    //            }
                    //        }
                    //    }

                    //using (AppDbContext context = new AppDbContext())
                    //{
                    //    var idUser = new IdentityUser
                    //    {
                    //        UserName = model.Name,
                    //        Email = model.Email,
                    //        PhoneNumber = model.Phone,
                    //        NormalizedEmail = model.Email
                    //    };
                    //    //IdentityUser u =await _userRepository.RegisterIdentityUser(_userManager, model, idUser);
                    //    var passwordHash = new PasswordHasher<IdentityUser>().HashPassword(idUser, model.Password);
                    //    idUser.PasswordHash = passwordHash;
                    //    User user = new User
                    //    {
                    //        Id = idUser.Id,
                    //        Location = model.Location,
                    //        ProfileImage = model.ProfileImage,
                    //        IdentityUser = idUser
                    //    };
                    //    using (_userManager)
                    //    {
                    //      await  _userRepository.RegisterIdentityUser(_userManager, model, idUser);
                    //    }

                    //    string id= await   _userRepository.RegisterApplicationUser(context, user);
                    //    context.SaveChanges();
                    //    user.Id = id;
                    //    if (model.UserType == "Freelancer")
                    //    {
                    //        Profile profile = new Profile
                    //        {
                    //            Description = "asd",
                    //            User = user
                    //        };
                    //        _userRepository.CreateProfile(context, profile);
                    //        context.SaveChanges();
                    //    }
                    //}
                    return model.Name;
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
                    List<User> list= _userRepository.GetUsers(context);
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateUser(ProfileViewModel user)        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                     _userRepository.UpdateUser(context,user);
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
                   return _userRepository.GetUserDetails(context,userId);
                }
             }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
